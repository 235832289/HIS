using System;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
//using com.digitalwave.iCare.middletier.HRPService;
using System.Data;
using iCareData;
using iCare.iCareBaseForm;
using System.Threading;
using com.digitalwave.Utility.SQLConvert;
using com.digitalwave.PatientManagerService;
using StaticObject = com.digitalwave.Emr.StaticObject;
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.iCare.ValueObject;
using System.Reflection;
using com.digitalwave.Emr.Initializer;

namespace iCare
{
	/// <summary>
	/// 临床数据检索
	/// </summary>
	public class frmDataSearches : frmBaseForm
	{
		#region Define
		private clsDataSearchesMake m_objMakeInfo;
		private RecordSearch.clsRecordSearchDomain m_objRecordSearchDomain;
		private clsInpatMedRec_Type[] m_objTypeArr = null;
		private Hashtable m_hasPatientID;
		private Hashtable m_hasPatientIDAndDate;
	
		private System.Windows.Forms.ImageList imlMain;
		private System.Windows.Forms.ListView m_lsvPatientList;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Label m_lblPatientCount;
		private PinkieControls.ButtonXP m_cmdSearch;
		private PinkieControls.ButtonXP m_cmdClearResult;
		private System.Windows.Forms.Label m_lblPatientTimesCount;
		private System.Windows.Forms.ContextMenu m_ctmConditionList;
		private System.Windows.Forms.MenuItem m_mniModifyCondition;
		private System.Windows.Forms.MenuItem m_mniDeleteCondition;
		private System.Windows.Forms.MenuItem m_mniClearCondition;
		private System.Windows.Forms.ContextMenu m_ctmExplorer;
		private System.Windows.Forms.MenuItem m_mnuInPatient;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem38;
		private System.Windows.Forms.MenuItem menuItem39;
		private System.Windows.Forms.MenuItem menuItem40;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem menuItem25;
		private System.Windows.Forms.MenuItem menuItem26;
		private System.Windows.Forms.MenuItem mniEKGOrder;
		private System.Windows.Forms.MenuItem mniNuclearOrder;
		private System.Windows.Forms.MenuItem mniPSGOrder;
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
		private System.Windows.Forms.MenuItem menuItem41;
		private System.Windows.Forms.MenuItem menuItem42;
		private System.Windows.Forms.MenuItem menuItem43;
		private System.Windows.Forms.MenuItem mniICUTendRecord;
		private System.Windows.Forms.MenuItem menuItem44;
		private System.Windows.Forms.MenuItem menuItem45;
		private System.Windows.Forms.MenuItem menuItem46;
		internal System.Windows.Forms.ListBox m_lstConditionList;
		private PinkieControls.ButtonXP m_cmdAddCondition;
		private PinkieControls.ButtonXP m_cmdClearCondition;
		internal System.Windows.Forms.Panel m_pnlTrueFalse;
		internal System.Windows.Forms.RadioButton m_rdbTrueFalseTrue;
		internal System.Windows.Forms.RadioButton m_rdbTrueFalseFalse;
		internal System.Windows.Forms.Panel m_pnlNumber;
		internal com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtNumberFrom;
		internal System.Windows.Forms.Label m_lblNumberFrom;
		internal System.Windows.Forms.Label m_lblNumberTo;
		internal com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtNumberTo;
		internal com.digitalwave.Utility.Controls.ctlComboBox m_cboNumberConditionType;
		internal System.Windows.Forms.Label lblNumberConditionType;
		internal System.Windows.Forms.Panel m_pnlLongText;
		internal com.digitalwave.Utility.Controls.ctlComboBox m_cboLongTextConditionType;
		internal System.Windows.Forms.Label lblLongTextConditionType;
		internal com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtLongTextContent;
		internal System.Windows.Forms.Panel m_pnlDate;
		internal com.digitalwave.Utility.Controls.ctlTimePicker m_dtpSecond;
		internal com.digitalwave.Utility.Controls.ctlComboBox m_cboDateConditionType;
		internal System.Windows.Forms.Label lblDateConditionType;
		internal System.Windows.Forms.Label m_lblDateTo;
		internal com.digitalwave.Utility.Controls.ctlTimePicker m_dtpFirst;
		internal System.Windows.Forms.Label m_lblDateFrom;
		private System.Windows.Forms.TreeView m_trvMain;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.GroupBox gpbCondition;
		private System.Windows.Forms.GroupBox gpbConditionList;
		private System.Windows.Forms.Label m_lblMessage;
		private System.Windows.Forms.TextBox m_txtPatientInfo;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.ToolTip ttpMain;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem47;
		private System.Windows.Forms.MenuItem menuItem48;
		private System.Windows.Forms.MenuItem menuItem49;
		private System.Windows.Forms.MenuItem menuItem50;
		private System.Windows.Forms.MenuItem menuItem51;
		private System.Windows.Forms.MenuItem menuItem54;
		private System.Windows.Forms.MenuItem menuItem56;
		private System.Windows.Forms.MenuItem menuItem52;
		private System.Windows.Forms.MenuItem menuItem53;
		private System.Windows.Forms.MenuItem menuItem55;
		private System.Windows.Forms.MenuItem menuItem57;
		private System.Windows.Forms.MenuItem m_mtmInpatMedRec;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboDept;
        private CheckBox m_chkCurrentDept;
        private CheckBox m_chkAllDept;
		private System.ComponentModel.IContainer components;
        /// <summary>
        /// 医嘱状态设置:
        /// </summary>
        private clsOrderStatus_VO m_objOrderStatus;
        private MenuItem m_mniOrder;
        private MenuItem m_mniCheckOut;
        private MenuItem m_mniExamine;
        private Panel pnlDept;
        private ContextMenuStrip m_cmsEMRMenu;
        private ArrayList m_arlFindOrderSQL = new ArrayList();

		#endregion

		public frmDataSearches()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_hasPatientID = new Hashtable();
			m_hasPatientIDAndDate = new Hashtable();
			m_objMakeInfo = new clsDataSearchesMake();
            m_objRecordSearchDomain = new RecordSearch.clsRecordSearchDomain();

            if (StaticObject::clsEMR_StaticObject.s_StrCurrentHospitalNO != "450101001")//非南宁
            {
                m_mniExamine.Visible = false;
                m_mniCheckOut.Visible = false;
                m_mniOrder.Visible = false;
            }

            m_mthGetOrderStatus();
			m_mthInitTreeContent();
            //m_mthInitMenu();
            m_mthInitEMRMenu();
			m_mthAddComboItem();
			new clsSortTool().m_mthSetListViewSortable(m_lsvPatientList);
			new com.digitalwave.Utility.Controls.ctlHighLightFocus(com.digitalwave.Utility.Controls.clsHRPColor.s_ClrHightLight).m_mthAddControlInContainer(this);
			m_mthSetMenuItemVisible();

            m_mthGetDeptInfo();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataSearches));
            this.m_trvMain = new System.Windows.Forms.TreeView();
            this.imlMain = new System.Windows.Forms.ImageList(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.gpbCondition = new System.Windows.Forms.GroupBox();
            this.m_cmdAddCondition = new PinkieControls.ButtonXP();
            this.m_cmdClearCondition = new PinkieControls.ButtonXP();
            this.m_pnlLongText = new System.Windows.Forms.Panel();
            this.m_cboLongTextConditionType = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.lblLongTextConditionType = new System.Windows.Forms.Label();
            this.m_txtLongTextContent = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_pnlDate = new System.Windows.Forms.Panel();
            this.m_dtpSecond = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_lblDateTo = new System.Windows.Forms.Label();
            this.m_cboDateConditionType = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.lblDateConditionType = new System.Windows.Forms.Label();
            this.m_dtpFirst = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_lblDateFrom = new System.Windows.Forms.Label();
            this.m_pnlNumber = new System.Windows.Forms.Panel();
            this.m_txtNumberTo = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtNumberFrom = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_lblNumberFrom = new System.Windows.Forms.Label();
            this.m_lblNumberTo = new System.Windows.Forms.Label();
            this.m_cboNumberConditionType = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.lblNumberConditionType = new System.Windows.Forms.Label();
            this.m_pnlTrueFalse = new System.Windows.Forms.Panel();
            this.m_rdbTrueFalseTrue = new System.Windows.Forms.RadioButton();
            this.m_rdbTrueFalseFalse = new System.Windows.Forms.RadioButton();
            this.gpbConditionList = new System.Windows.Forms.GroupBox();
            this.m_lstConditionList = new System.Windows.Forms.ListBox();
            this.m_ctmConditionList = new System.Windows.Forms.ContextMenu();
            this.m_mniModifyCondition = new System.Windows.Forms.MenuItem();
            this.m_mniDeleteCondition = new System.Windows.Forms.MenuItem();
            this.m_mniClearCondition = new System.Windows.Forms.MenuItem();
            this.m_lsvPatientList = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.m_cmsEMRMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_ctmExplorer = new System.Windows.Forms.ContextMenu();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.m_mnuInPatient = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem51 = new System.Windows.Forms.MenuItem();
            this.menuItem54 = new System.Windows.Forms.MenuItem();
            this.menuItem56 = new System.Windows.Forms.MenuItem();
            this.menuItem55 = new System.Windows.Forms.MenuItem();
            this.menuItem57 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem52 = new System.Windows.Forms.MenuItem();
            this.menuItem53 = new System.Windows.Forms.MenuItem();
            this.m_mtmInpatMedRec = new System.Windows.Forms.MenuItem();
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
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem42 = new System.Windows.Forms.MenuItem();
            this.menuItem43 = new System.Windows.Forms.MenuItem();
            this.mniICUTendRecord = new System.Windows.Forms.MenuItem();
            this.menuItem44 = new System.Windows.Forms.MenuItem();
            this.menuItem45 = new System.Windows.Forms.MenuItem();
            this.menuItem46 = new System.Windows.Forms.MenuItem();
            this.menuItem47 = new System.Windows.Forms.MenuItem();
            this.menuItem48 = new System.Windows.Forms.MenuItem();
            this.menuItem49 = new System.Windows.Forms.MenuItem();
            this.menuItem50 = new System.Windows.Forms.MenuItem();
            this.m_mniOrder = new System.Windows.Forms.MenuItem();
            this.m_mniCheckOut = new System.Windows.Forms.MenuItem();
            this.m_mniExamine = new System.Windows.Forms.MenuItem();
            this.m_lblPatientCount = new System.Windows.Forms.Label();
            this.m_cmdSearch = new PinkieControls.ButtonXP();
            this.m_cmdClearResult = new PinkieControls.ButtonXP();
            this.m_lblPatientTimesCount = new System.Windows.Forms.Label();
            this.m_lblMessage = new System.Windows.Forms.Label();
            this.m_txtPatientInfo = new System.Windows.Forms.TextBox();
            this.ttpMain = new System.Windows.Forms.ToolTip(this.components);
            this.m_cboDept = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_chkCurrentDept = new System.Windows.Forms.CheckBox();
            this.m_chkAllDept = new System.Windows.Forms.CheckBox();
            this.pnlDept = new System.Windows.Forms.Panel();
            this.gpbCondition.SuspendLayout();
            this.m_pnlLongText.SuspendLayout();
            this.m_pnlDate.SuspendLayout();
            this.m_pnlNumber.SuspendLayout();
            this.m_pnlTrueFalse.SuspendLayout();
            this.gpbConditionList.SuspendLayout();
            this.pnlDept.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvMain
            // 
            this.m_trvMain.BackColor = System.Drawing.Color.White;
            this.m_trvMain.ForeColor = System.Drawing.Color.Black;
            this.m_trvMain.HotTracking = true;
            this.m_trvMain.ImageIndex = 0;
            this.m_trvMain.ImageList = this.imlMain;
            this.m_trvMain.Location = new System.Drawing.Point(5, 56);
            this.m_trvMain.Name = "m_trvMain";
            this.m_trvMain.PathSeparator = ">>";
            this.m_trvMain.SelectedImageIndex = 3;
            this.m_trvMain.ShowNodeToolTips = true;
            this.m_trvMain.Size = new System.Drawing.Size(262, 524);
            this.m_trvMain.TabIndex = 0;
            this.m_trvMain.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_trvMain_BeforeExpand);
            this.m_trvMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvMain_AfterSelect);
            this.m_trvMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_trvMain_MouseMove);
            // 
            // imlMain
            // 
            this.imlMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMain.ImageStream")));
            this.imlMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imlMain.Images.SetKeyName(0, "");
            this.imlMain.Images.SetKeyName(1, "");
            this.imlMain.Images.SetKeyName(2, "");
            this.imlMain.Images.SetKeyName(3, "");
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("宋体", 26F);
            this.lblTitle.Location = new System.Drawing.Point(181, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(4, 4);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "临  床  数  据  检  索";
            // 
            // gpbCondition
            // 
            this.gpbCondition.Controls.Add(this.m_cmdAddCondition);
            this.gpbCondition.Controls.Add(this.m_cmdClearCondition);
            this.gpbCondition.Controls.Add(this.m_pnlLongText);
            this.gpbCondition.Controls.Add(this.m_pnlDate);
            this.gpbCondition.Controls.Add(this.m_pnlNumber);
            this.gpbCondition.Controls.Add(this.m_pnlTrueFalse);
            this.gpbCondition.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gpbCondition.Location = new System.Drawing.Point(270, 56);
            this.gpbCondition.Name = "gpbCondition";
            this.gpbCondition.Size = new System.Drawing.Size(292, 184);
            this.gpbCondition.TabIndex = 100;
            this.gpbCondition.TabStop = false;
            this.gpbCondition.Text = "查询条件";
            // 
            // m_cmdAddCondition
            // 
            this.m_cmdAddCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdAddCondition.DefaultScheme = true;
            this.m_cmdAddCondition.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddCondition.Hint = "";
            this.m_cmdAddCondition.Location = new System.Drawing.Point(44, 148);
            this.m_cmdAddCondition.Name = "m_cmdAddCondition";
            this.m_cmdAddCondition.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddCondition.Size = new System.Drawing.Size(76, 28);
            this.m_cmdAddCondition.TabIndex = 500;
            this.m_cmdAddCondition.Text = "添加条件";
            this.m_cmdAddCondition.Click += new System.EventHandler(this.m_cmdAddCondition_Click);
            // 
            // m_cmdClearCondition
            // 
            this.m_cmdClearCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdClearCondition.DefaultScheme = true;
            this.m_cmdClearCondition.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClearCondition.Hint = "";
            this.m_cmdClearCondition.Location = new System.Drawing.Point(188, 148);
            this.m_cmdClearCondition.Name = "m_cmdClearCondition";
            this.m_cmdClearCondition.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClearCondition.Size = new System.Drawing.Size(80, 28);
            this.m_cmdClearCondition.TabIndex = 5500;
            this.m_cmdClearCondition.Text = "清空条件";
            this.m_cmdClearCondition.Click += new System.EventHandler(this.m_cmdClearCondition_Click);
            // 
            // m_pnlLongText
            // 
            this.m_pnlLongText.Controls.Add(this.m_cboLongTextConditionType);
            this.m_pnlLongText.Controls.Add(this.lblLongTextConditionType);
            this.m_pnlLongText.Controls.Add(this.m_txtLongTextContent);
            this.m_pnlLongText.Location = new System.Drawing.Point(8, 28);
            this.m_pnlLongText.Name = "m_pnlLongText";
            this.m_pnlLongText.Size = new System.Drawing.Size(276, 108);
            this.m_pnlLongText.TabIndex = 110;
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
            this.m_cboLongTextConditionType.ListBackColor = System.Drawing.Color.White;
            this.m_cboLongTextConditionType.ListForeColor = System.Drawing.Color.Black;
            this.m_cboLongTextConditionType.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboLongTextConditionType.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboLongTextConditionType.Location = new System.Drawing.Point(96, 8);
            this.m_cboLongTextConditionType.m_BlnEnableItemEventMenu = false;
            this.m_cboLongTextConditionType.Name = "m_cboLongTextConditionType";
            this.m_cboLongTextConditionType.SelectedIndex = -1;
            this.m_cboLongTextConditionType.SelectedItem = null;
            this.m_cboLongTextConditionType.SelectionStart = 0;
            this.m_cboLongTextConditionType.Size = new System.Drawing.Size(168, 23);
            this.m_cboLongTextConditionType.TabIndex = 3000;
            this.m_cboLongTextConditionType.TextBackColor = System.Drawing.Color.White;
            this.m_cboLongTextConditionType.TextForeColor = System.Drawing.Color.Black;
            this.m_cboLongTextConditionType.SelectedIndexChanged += new System.EventHandler(this.m_cboLongTextConditionType_SelectedIndexChanged);
            // 
            // lblLongTextConditionType
            // 
            this.lblLongTextConditionType.AutoSize = true;
            this.lblLongTextConditionType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblLongTextConditionType.Location = new System.Drawing.Point(8, 12);
            this.lblLongTextConditionType.Name = "lblLongTextConditionType";
            this.lblLongTextConditionType.Size = new System.Drawing.Size(77, 14);
            this.lblLongTextConditionType.TabIndex = 10000006;
            this.lblLongTextConditionType.Text = "条件类型：";
            // 
            // m_txtLongTextContent
            // 
            this.m_txtLongTextContent.BackColor = System.Drawing.Color.White;
            this.m_txtLongTextContent.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtLongTextContent.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtLongTextContent.ForeColor = System.Drawing.Color.Black;
            this.m_txtLongTextContent.Location = new System.Drawing.Point(8, 48);
            this.m_txtLongTextContent.Name = "m_txtLongTextContent";
            this.m_txtLongTextContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_txtLongTextContent.Size = new System.Drawing.Size(256, 23);
            this.m_txtLongTextContent.TabIndex = 120;
            this.m_txtLongTextContent.GotFocus += new System.EventHandler(this.m_txtLongTextContent_GotFocus);
            // 
            // m_pnlDate
            // 
            this.m_pnlDate.Controls.Add(this.m_dtpSecond);
            this.m_pnlDate.Controls.Add(this.m_lblDateTo);
            this.m_pnlDate.Controls.Add(this.m_cboDateConditionType);
            this.m_pnlDate.Controls.Add(this.lblDateConditionType);
            this.m_pnlDate.Controls.Add(this.m_dtpFirst);
            this.m_pnlDate.Controls.Add(this.m_lblDateFrom);
            this.m_pnlDate.Font = new System.Drawing.Font("宋体", 12F);
            this.m_pnlDate.Location = new System.Drawing.Point(8, 28);
            this.m_pnlDate.Name = "m_pnlDate";
            this.m_pnlDate.Size = new System.Drawing.Size(276, 108);
            this.m_pnlDate.TabIndex = 200;
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
            this.m_dtpSecond.Location = new System.Drawing.Point(108, 66);
            this.m_dtpSecond.m_BlnOnlyTime = false;
            this.m_dtpSecond.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpSecond.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpSecond.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpSecond.Name = "m_dtpSecond";
            this.m_dtpSecond.ReadOnly = false;
            this.m_dtpSecond.Size = new System.Drawing.Size(140, 22);
            this.m_dtpSecond.TabIndex = 220;
            this.m_dtpSecond.TextBackColor = System.Drawing.Color.White;
            this.m_dtpSecond.TextForeColor = System.Drawing.Color.Black;
            this.m_dtpSecond.Visible = false;
            // 
            // m_lblDateTo
            // 
            this.m_lblDateTo.AutoSize = true;
            this.m_lblDateTo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblDateTo.Location = new System.Drawing.Point(64, 68);
            this.m_lblDateTo.Name = "m_lblDateTo";
            this.m_lblDateTo.Size = new System.Drawing.Size(28, 14);
            this.m_lblDateTo.TabIndex = 10000004;
            this.m_lblDateTo.Text = "到:";
            this.m_lblDateTo.Visible = false;
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
            this.m_cboDateConditionType.ListBackColor = System.Drawing.Color.White;
            this.m_cboDateConditionType.ListForeColor = System.Drawing.Color.Black;
            this.m_cboDateConditionType.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboDateConditionType.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboDateConditionType.Location = new System.Drawing.Point(108, 8);
            this.m_cboDateConditionType.m_BlnEnableItemEventMenu = false;
            this.m_cboDateConditionType.Name = "m_cboDateConditionType";
            this.m_cboDateConditionType.SelectedIndex = -1;
            this.m_cboDateConditionType.SelectedItem = null;
            this.m_cboDateConditionType.SelectionStart = 0;
            this.m_cboDateConditionType.Size = new System.Drawing.Size(140, 23);
            this.m_cboDateConditionType.TabIndex = 3000;
            this.m_cboDateConditionType.TextBackColor = System.Drawing.Color.White;
            this.m_cboDateConditionType.TextForeColor = System.Drawing.Color.Black;
            this.m_cboDateConditionType.SelectedIndexChanged += new System.EventHandler(this.m_cboDateConditionType_SelectedIndexChanged);
            // 
            // lblDateConditionType
            // 
            this.lblDateConditionType.AutoSize = true;
            this.lblDateConditionType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblDateConditionType.Location = new System.Drawing.Point(21, 12);
            this.lblDateConditionType.Name = "lblDateConditionType";
            this.lblDateConditionType.Size = new System.Drawing.Size(70, 14);
            this.lblDateConditionType.TabIndex = 10000008;
            this.lblDateConditionType.Text = "条件类型:";
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
            this.m_dtpFirst.Location = new System.Drawing.Point(108, 40);
            this.m_dtpFirst.m_BlnOnlyTime = false;
            this.m_dtpFirst.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpFirst.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpFirst.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpFirst.Name = "m_dtpFirst";
            this.m_dtpFirst.ReadOnly = false;
            this.m_dtpFirst.Size = new System.Drawing.Size(140, 22);
            this.m_dtpFirst.TabIndex = 210;
            this.m_dtpFirst.TextBackColor = System.Drawing.Color.White;
            this.m_dtpFirst.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_lblDateFrom
            // 
            this.m_lblDateFrom.AutoSize = true;
            this.m_lblDateFrom.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblDateFrom.Location = new System.Drawing.Point(64, 44);
            this.m_lblDateFrom.Name = "m_lblDateFrom";
            this.m_lblDateFrom.Size = new System.Drawing.Size(28, 14);
            this.m_lblDateFrom.TabIndex = 10000004;
            this.m_lblDateFrom.Text = "从:";
            this.m_lblDateFrom.Visible = false;
            // 
            // m_pnlNumber
            // 
            this.m_pnlNumber.Controls.Add(this.m_txtNumberTo);
            this.m_pnlNumber.Controls.Add(this.m_txtNumberFrom);
            this.m_pnlNumber.Controls.Add(this.m_lblNumberFrom);
            this.m_pnlNumber.Controls.Add(this.m_lblNumberTo);
            this.m_pnlNumber.Controls.Add(this.m_cboNumberConditionType);
            this.m_pnlNumber.Controls.Add(this.lblNumberConditionType);
            this.m_pnlNumber.Font = new System.Drawing.Font("宋体", 12F);
            this.m_pnlNumber.Location = new System.Drawing.Point(8, 28);
            this.m_pnlNumber.Name = "m_pnlNumber";
            this.m_pnlNumber.Size = new System.Drawing.Size(276, 108);
            this.m_pnlNumber.TabIndex = 300;
            // 
            // m_txtNumberTo
            // 
            this.m_txtNumberTo.BackColor = System.Drawing.Color.White;
            this.m_txtNumberTo.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtNumberTo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtNumberTo.ForeColor = System.Drawing.Color.Black;
            this.m_txtNumberTo.Location = new System.Drawing.Point(192, 52);
            this.m_txtNumberTo.Name = "m_txtNumberTo";
            this.m_txtNumberTo.Size = new System.Drawing.Size(72, 23);
            this.m_txtNumberTo.TabIndex = 320;
            this.m_txtNumberTo.Visible = false;
            // 
            // m_txtNumberFrom
            // 
            this.m_txtNumberFrom.BackColor = System.Drawing.Color.White;
            this.m_txtNumberFrom.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtNumberFrom.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtNumberFrom.ForeColor = System.Drawing.Color.Black;
            this.m_txtNumberFrom.Location = new System.Drawing.Point(96, 52);
            this.m_txtNumberFrom.Name = "m_txtNumberFrom";
            this.m_txtNumberFrom.Size = new System.Drawing.Size(72, 23);
            this.m_txtNumberFrom.TabIndex = 310;
            // 
            // m_lblNumberFrom
            // 
            this.m_lblNumberFrom.AutoSize = true;
            this.m_lblNumberFrom.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblNumberFrom.Location = new System.Drawing.Point(40, 52);
            this.m_lblNumberFrom.Name = "m_lblNumberFrom";
            this.m_lblNumberFrom.Size = new System.Drawing.Size(42, 14);
            this.m_lblNumberFrom.TabIndex = 10000004;
            this.m_lblNumberFrom.Text = "数值:";
            // 
            // m_lblNumberTo
            // 
            this.m_lblNumberTo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblNumberTo.Location = new System.Drawing.Point(172, 56);
            this.m_lblNumberTo.Name = "m_lblNumberTo";
            this.m_lblNumberTo.Size = new System.Drawing.Size(16, 24);
            this.m_lblNumberTo.TabIndex = 10000004;
            this.m_lblNumberTo.Text = "~";
            this.m_lblNumberTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_lblNumberTo.Visible = false;
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
            this.m_cboNumberConditionType.ListBackColor = System.Drawing.Color.White;
            this.m_cboNumberConditionType.ListForeColor = System.Drawing.Color.Black;
            this.m_cboNumberConditionType.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboNumberConditionType.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboNumberConditionType.Location = new System.Drawing.Point(88, 8);
            this.m_cboNumberConditionType.m_BlnEnableItemEventMenu = false;
            this.m_cboNumberConditionType.Name = "m_cboNumberConditionType";
            this.m_cboNumberConditionType.SelectedIndex = -1;
            this.m_cboNumberConditionType.SelectedItem = null;
            this.m_cboNumberConditionType.SelectionStart = 0;
            this.m_cboNumberConditionType.Size = new System.Drawing.Size(176, 23);
            this.m_cboNumberConditionType.TabIndex = 3000;
            this.m_cboNumberConditionType.TextBackColor = System.Drawing.Color.White;
            this.m_cboNumberConditionType.TextForeColor = System.Drawing.Color.Black;
            this.m_cboNumberConditionType.SelectedIndexChanged += new System.EventHandler(this.m_cboNumberConditionType_SelectedIndexChanged);
            // 
            // lblNumberConditionType
            // 
            this.lblNumberConditionType.AutoSize = true;
            this.lblNumberConditionType.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblNumberConditionType.Location = new System.Drawing.Point(12, 12);
            this.lblNumberConditionType.Name = "lblNumberConditionType";
            this.lblNumberConditionType.Size = new System.Drawing.Size(70, 14);
            this.lblNumberConditionType.TabIndex = 10000004;
            this.lblNumberConditionType.Text = "条件类型:";
            // 
            // m_pnlTrueFalse
            // 
            this.m_pnlTrueFalse.Controls.Add(this.m_rdbTrueFalseTrue);
            this.m_pnlTrueFalse.Controls.Add(this.m_rdbTrueFalseFalse);
            this.m_pnlTrueFalse.Font = new System.Drawing.Font("宋体", 12F);
            this.m_pnlTrueFalse.Location = new System.Drawing.Point(8, 28);
            this.m_pnlTrueFalse.Name = "m_pnlTrueFalse";
            this.m_pnlTrueFalse.Size = new System.Drawing.Size(276, 108);
            this.m_pnlTrueFalse.TabIndex = 400;
            // 
            // m_rdbTrueFalseTrue
            // 
            this.m_rdbTrueFalseTrue.Checked = true;
            this.m_rdbTrueFalseTrue.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_rdbTrueFalseTrue.Location = new System.Drawing.Point(8, 12);
            this.m_rdbTrueFalseTrue.Name = "m_rdbTrueFalseTrue";
            this.m_rdbTrueFalseTrue.Size = new System.Drawing.Size(96, 24);
            this.m_rdbTrueFalseTrue.TabIndex = 410;
            this.m_rdbTrueFalseTrue.TabStop = true;
            this.m_rdbTrueFalseTrue.Text = "条件成立";
            // 
            // m_rdbTrueFalseFalse
            // 
            this.m_rdbTrueFalseFalse.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_rdbTrueFalseFalse.Location = new System.Drawing.Point(8, 48);
            this.m_rdbTrueFalseFalse.Name = "m_rdbTrueFalseFalse";
            this.m_rdbTrueFalseFalse.Size = new System.Drawing.Size(120, 24);
            this.m_rdbTrueFalseFalse.TabIndex = 420;
            this.m_rdbTrueFalseFalse.Text = "条件不成立";
            // 
            // gpbConditionList
            // 
            this.gpbConditionList.Controls.Add(this.m_lstConditionList);
            this.gpbConditionList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gpbConditionList.Location = new System.Drawing.Point(270, 248);
            this.gpbConditionList.Name = "gpbConditionList";
            this.gpbConditionList.Size = new System.Drawing.Size(292, 332);
            this.gpbConditionList.TabIndex = 1100;
            this.gpbConditionList.TabStop = false;
            this.gpbConditionList.Text = "条件列表";
            // 
            // m_lstConditionList
            // 
            this.m_lstConditionList.BackColor = System.Drawing.Color.White;
            this.m_lstConditionList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lstConditionList.ContextMenu = this.m_ctmConditionList;
            this.m_lstConditionList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_lstConditionList.ForeColor = System.Drawing.Color.Black;
            this.m_lstConditionList.HorizontalScrollbar = true;
            this.m_lstConditionList.ItemHeight = 14;
            this.m_lstConditionList.Location = new System.Drawing.Point(3, 33);
            this.m_lstConditionList.Name = "m_lstConditionList";
            this.m_lstConditionList.Size = new System.Drawing.Size(286, 296);
            this.m_lstConditionList.TabIndex = 1103;
            this.m_lstConditionList.DoubleClick += new System.EventHandler(this.m_lstConditionList_DoubleClick);
            // 
            // m_ctmConditionList
            // 
            this.m_ctmConditionList.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_mniModifyCondition,
            this.m_mniDeleteCondition,
            this.m_mniClearCondition});
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
            // m_lsvPatientList
            // 
            this.m_lsvPatientList.BackColor = System.Drawing.Color.White;
            this.m_lsvPatientList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader3});
            this.m_lsvPatientList.ContextMenuStrip = this.m_cmsEMRMenu;
            this.m_lsvPatientList.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lsvPatientList.ForeColor = System.Drawing.Color.Black;
            this.m_lsvPatientList.FullRowSelect = true;
            this.m_lsvPatientList.GridLines = true;
            this.m_lsvPatientList.HideSelection = false;
            this.m_lsvPatientList.Location = new System.Drawing.Point(570, 56);
            this.m_lsvPatientList.MultiSelect = false;
            this.m_lsvPatientList.Name = "m_lsvPatientList";
            this.m_lsvPatientList.Size = new System.Drawing.Size(296, 360);
            this.m_lsvPatientList.TabIndex = 700;
            this.m_lsvPatientList.UseCompatibleStateImageBehavior = false;
            this.m_lsvPatientList.View = System.Windows.Forms.View.Details;
            this.m_lsvPatientList.SelectedIndexChanged += new System.EventHandler(this.m_lsvPatientList_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "姓名";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "住院号";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "住院日期";
            this.columnHeader3.Width = 130;
            // 
            // m_cmsEMRMenu
            // 
            this.m_cmsEMRMenu.Name = "m_cmsEMRMenu";
            this.m_cmsEMRMenu.Size = new System.Drawing.Size(153, 26);
            this.m_cmsEMRMenu.Opening += new System.ComponentModel.CancelEventHandler(this.m_cmsEMRMenu_Opening);
            // 
            // m_ctmExplorer
            // 
            this.m_ctmExplorer.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5,
            this.m_mnuInPatient,
            this.menuItem4,
            this.menuItem9,
            this.menuItem12,
            this.menuItem13,
            this.menuItem51,
            this.menuItem54,
            this.menuItem56,
            this.menuItem55,
            this.menuItem57,
            this.menuItem16,
            this.menuItem52,
            this.menuItem53,
            this.m_mtmInpatMedRec,
            this.menuItem1,
            this.menuItem38,
            this.menuItem39,
            this.menuItem40,
            this.menuItem2,
            this.menuItem3,
            this.menuItem37,
            this.m_mniOrder,
            this.m_mniCheckOut,
            this.m_mniExamine});
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.Text = "住院病案首页";
            // 
            // m_mnuInPatient
            // 
            this.m_mnuInPatient.Index = 1;
            this.m_mnuInPatient.Text = "住院病历";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "住院病历(自由录入风格)";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 3;
            this.menuItem9.Text = "病程记录";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 4;
            this.menuItem12.Text = "术前小结";
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 5;
            this.menuItem13.Text = "手术记录单";
            // 
            // menuItem51
            // 
            this.menuItem51.Index = 6;
            this.menuItem51.Text = "手术通知单";
            // 
            // menuItem54
            // 
            this.menuItem54.Index = 7;
            this.menuItem54.Text = "术前术后访视单";
            // 
            // menuItem56
            // 
            this.menuItem56.Index = 8;
            this.menuItem56.Text = "麻醉记录单";
            // 
            // menuItem55
            // 
            this.menuItem55.Index = 9;
            this.menuItem55.Text = "24小时内入出院记录";
            // 
            // menuItem57
            // 
            this.menuItem57.Index = 10;
            this.menuItem57.Text = "入院24小时内死亡记录";
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 11;
            this.menuItem16.Text = "出院记录";
            // 
            // menuItem52
            // 
            this.menuItem52.Index = 12;
            this.menuItem52.Text = "死亡记录";
            // 
            // menuItem53
            // 
            this.menuItem53.Index = 13;
            this.menuItem53.Text = "死亡病例讨论记录";
            // 
            // m_mtmInpatMedRec
            // 
            this.m_mtmInpatMedRec.Index = 14;
            this.m_mtmInpatMedRec.Text = "专科病历";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 15;
            this.menuItem1.Text = "-";
            // 
            // menuItem38
            // 
            this.menuItem38.Index = 16;
            this.menuItem38.Text = "入院病人评估";
            // 
            // menuItem39
            // 
            this.menuItem39.Index = 17;
            this.menuItem39.Text = "三 测 表";
            // 
            // menuItem40
            // 
            this.menuItem40.Index = 18;
            this.menuItem40.Text = "一般护理记录";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 19;
            this.menuItem2.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 20;
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
            this.menuItem37.Index = 21;
            this.menuItem37.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniPatientInfoManage,
            this.menuItem41,
            this.menuItem7,
            this.menuItem42,
            this.menuItem43,
            this.mniICUTendRecord,
            this.menuItem44,
            this.menuItem45,
            this.menuItem46,
            this.menuItem47,
            this.menuItem48,
            this.menuItem49,
            this.menuItem50});
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
            // menuItem7
            // 
            this.menuItem7.Index = 2;
            this.menuItem7.Text = "一般患者护理记录";
            // 
            // menuItem42
            // 
            this.menuItem42.Index = 3;
            this.menuItem42.Text = "危重患者护理记录";
            // 
            // menuItem43
            // 
            this.menuItem43.Index = 4;
            this.menuItem43.Text = "危重症监护中心特护记录单";
            // 
            // mniICUTendRecord
            // 
            this.mniICUTendRecord.Index = 5;
            this.mniICUTendRecord.Text = "ICU危重患者护理记录";
            this.mniICUTendRecord.Visible = false;
            // 
            // menuItem44
            // 
            this.menuItem44.Index = 6;
            this.menuItem44.Text = "手术护理记录";
            // 
            // menuItem45
            // 
            this.menuItem45.Index = 7;
            this.menuItem45.Text = "手术器械、敷料点数表";
            // 
            // menuItem46
            // 
            this.menuItem46.Index = 8;
            this.menuItem46.Text = "中心ICU呼吸机治疗监护记录单";
            // 
            // menuItem47
            // 
            this.menuItem47.Index = 9;
            this.menuItem47.Text = "ICU护理记录";
            // 
            // menuItem48
            // 
            this.menuItem48.Index = 10;
            this.menuItem48.Text = "心血管外科护理记录";
            // 
            // menuItem49
            // 
            this.menuItem49.Index = 11;
            this.menuItem49.Text = "快速微量血糖检测记录表";
            // 
            // menuItem50
            // 
            this.menuItem50.Index = 12;
            this.menuItem50.Text = "外科ICU监护记录";
            // 
            // m_mniOrder
            // 
            this.m_mniOrder.Index = 22;
            this.m_mniOrder.Text = "医嘱";
            this.m_mniOrder.Click += new System.EventHandler(this.m_mniOrder_Click);
            // 
            // m_mniCheckOut
            // 
            this.m_mniCheckOut.Index = 23;
            this.m_mniCheckOut.Text = "检验";
            this.m_mniCheckOut.Click += new System.EventHandler(this.m_mniCheckOut_Click);
            // 
            // m_mniExamine
            // 
            this.m_mniExamine.Index = 24;
            this.m_mniExamine.Text = "检查";
            this.m_mniExamine.Click += new System.EventHandler(this.m_mniExamine_Click);
            // 
            // m_lblPatientCount
            // 
            this.m_lblPatientCount.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblPatientCount.Location = new System.Drawing.Point(566, 24);
            this.m_lblPatientCount.Name = "m_lblPatientCount";
            this.m_lblPatientCount.Size = new System.Drawing.Size(104, 24);
            this.m_lblPatientCount.TabIndex = 10000009;
            this.m_lblPatientCount.Text = "人数：";
            this.m_lblPatientCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cmdSearch
            // 
            this.m_cmdSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdSearch.DefaultScheme = true;
            this.m_cmdSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSearch.Font = new System.Drawing.Font("宋体", 12F);
            this.m_cmdSearch.Hint = "";
            this.m_cmdSearch.Location = new System.Drawing.Point(483, 20);
            this.m_cmdSearch.Name = "m_cmdSearch";
            this.m_cmdSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSearch.Size = new System.Drawing.Size(68, 28);
            this.m_cmdSearch.TabIndex = 600;
            this.m_cmdSearch.Text = "查  询";
            this.m_cmdSearch.Click += new System.EventHandler(this.m_cmdSearch_Click);
            // 
            // m_cmdClearResult
            // 
            this.m_cmdClearResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdClearResult.DefaultScheme = true;
            this.m_cmdClearResult.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClearResult.Font = new System.Drawing.Font("宋体", 12F);
            this.m_cmdClearResult.Hint = "";
            this.m_cmdClearResult.Location = new System.Drawing.Point(796, 20);
            this.m_cmdClearResult.Name = "m_cmdClearResult";
            this.m_cmdClearResult.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClearResult.Size = new System.Drawing.Size(68, 28);
            this.m_cmdClearResult.TabIndex = 10000006;
            this.m_cmdClearResult.Text = "清  空";
            this.m_cmdClearResult.Click += new System.EventHandler(this.m_cmdClearResult_Click);
            // 
            // m_lblPatientTimesCount
            // 
            this.m_lblPatientTimesCount.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblPatientTimesCount.Location = new System.Drawing.Point(680, 24);
            this.m_lblPatientTimesCount.Name = "m_lblPatientTimesCount";
            this.m_lblPatientTimesCount.Size = new System.Drawing.Size(112, 24);
            this.m_lblPatientTimesCount.TabIndex = 10000008;
            this.m_lblPatientTimesCount.Text = "人次：";
            this.m_lblPatientTimesCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblMessage
            // 
            this.m_lblMessage.AutoSize = true;
            this.m_lblMessage.Location = new System.Drawing.Point(3, 12);
            this.m_lblMessage.Name = "m_lblMessage";
            this.m_lblMessage.Size = new System.Drawing.Size(70, 14);
            this.m_lblMessage.TabIndex = 10000014;
            this.m_lblMessage.Text = "检索范围:";
            // 
            // m_txtPatientInfo
            // 
            this.m_txtPatientInfo.BackColor = System.Drawing.Color.White;
            this.m_txtPatientInfo.ForeColor = System.Drawing.Color.Black;
            this.m_txtPatientInfo.Location = new System.Drawing.Point(570, 420);
            this.m_txtPatientInfo.Multiline = true;
            this.m_txtPatientInfo.Name = "m_txtPatientInfo";
            this.m_txtPatientInfo.ReadOnly = true;
            this.m_txtPatientInfo.Size = new System.Drawing.Size(296, 160);
            this.m_txtPatientInfo.TabIndex = 800;
            // 
            // m_cboDept
            // 
            this.m_cboDept.AccessibleName = "NoDefault";
            this.m_cboDept.BackColor = System.Drawing.Color.White;
            this.m_cboDept.BorderColor = System.Drawing.Color.Black;
            this.m_cboDept.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
            this.m_cboDept.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboDept.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDept.Enabled = false;
            this.m_cboDept.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDept.ForeColor = System.Drawing.Color.Black;
            this.m_cboDept.ListBackColor = System.Drawing.SystemColors.ControlLight;
            this.m_cboDept.ListForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboDept.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboDept.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
            this.m_cboDept.Location = new System.Drawing.Point(278, 8);
            this.m_cboDept.m_BlnEnableItemEventMenu = false;
            this.m_cboDept.Name = "m_cboDept";
            this.m_cboDept.SelectedIndex = -1;
            this.m_cboDept.SelectedItem = null;
            this.m_cboDept.SelectionStart = 0;
            this.m_cboDept.Size = new System.Drawing.Size(144, 23);
            this.m_cboDept.TabIndex = 10000015;
            this.m_cboDept.TabStop = false;
            this.m_cboDept.TextBackColor = System.Drawing.Color.White;
            this.m_cboDept.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_chkCurrentDept
            // 
            this.m_chkCurrentDept.AutoSize = true;
            this.m_chkCurrentDept.Location = new System.Drawing.Point(190, 10);
            this.m_chkCurrentDept.Name = "m_chkCurrentDept";
            this.m_chkCurrentDept.Size = new System.Drawing.Size(82, 18);
            this.m_chkCurrentDept.TabIndex = 10000016;
            this.m_chkCurrentDept.Text = "当前科室";
            this.m_chkCurrentDept.UseVisualStyleBackColor = true;
            this.m_chkCurrentDept.CheckedChanged += new System.EventHandler(this.m_chkCurrentDept_CheckedChanged);
            // 
            // m_chkAllDept
            // 
            this.m_chkAllDept.AutoSize = true;
            this.m_chkAllDept.Location = new System.Drawing.Point(75, 10);
            this.m_chkAllDept.Name = "m_chkAllDept";
            this.m_chkAllDept.Size = new System.Drawing.Size(110, 18);
            this.m_chkAllDept.TabIndex = 10000017;
            this.m_chkAllDept.Text = "所有所属科室";
            this.m_chkAllDept.UseVisualStyleBackColor = true;
            this.m_chkAllDept.CheckedChanged += new System.EventHandler(this.m_chkAllDept_CheckedChanged);
            // 
            // pnlDept
            // 
            this.pnlDept.Controls.Add(this.m_lblMessage);
            this.pnlDept.Controls.Add(this.m_chkAllDept);
            this.pnlDept.Controls.Add(this.lblTitle);
            this.pnlDept.Controls.Add(this.m_chkCurrentDept);
            this.pnlDept.Controls.Add(this.m_cboDept);
            this.pnlDept.Location = new System.Drawing.Point(5, 12);
            this.pnlDept.Name = "pnlDept";
            this.pnlDept.Size = new System.Drawing.Size(441, 36);
            this.pnlDept.TabIndex = 10000018;
            // 
            // frmDataSearches
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(912, 589);
            this.Controls.Add(this.pnlDept);
            this.Controls.Add(this.m_txtPatientInfo);
            this.Controls.Add(this.m_cmdSearch);
            this.Controls.Add(this.m_cmdClearResult);
            this.Controls.Add(this.m_lblPatientCount);
            this.Controls.Add(this.m_lblPatientTimesCount);
            this.Controls.Add(this.m_lsvPatientList);
            this.Controls.Add(this.gpbCondition);
            this.Controls.Add(this.m_trvMain);
            this.Controls.Add(this.gpbConditionList);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDataSearches";
            this.Text = "临床数据检索";
            this.gpbCondition.ResumeLayout(false);
            this.m_pnlLongText.ResumeLayout(false);
            this.m_pnlLongText.PerformLayout();
            this.m_pnlDate.ResumeLayout(false);
            this.m_pnlDate.PerformLayout();
            this.m_pnlNumber.ResumeLayout(false);
            this.m_pnlNumber.PerformLayout();
            this.m_pnlTrueFalse.ResumeLayout(false);
            this.gpbConditionList.ResumeLayout(false);
            this.pnlDept.ResumeLayout(false);
            this.pnlDept.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        #region 获取医嘱状态
        /// <summary>
        /// 获取医嘱状态
        /// </summary>
        private void m_mthGetOrderStatus()
        {
            try
            {
                if (StaticObject::clsEMR_StaticObject.s_StrCurrentHospitalNO == "450101001")//南宁
                {
                    m_objRecordSearchDomain.m_lngGetOrderStatusDicMap(out m_objOrderStatus);

                    if (m_objOrderStatus == null)
                    {
                        clsPublicFunction.ShowInformationMessageBox("初始化数据出错！");
                    }
                }

            }
            catch (Exception exp)
            {
                clsPublicFunction.ShowInformationMessageBox("初始化医嘱数据出错！"+exp.Message);
            }
            
        } 
        #endregion

		#region Initialize Tree
		/// <summary>
		/// 初始化树结点
		/// </summary>
		private void m_mthInitTreeContent()
		{
			clsKeyAndFormName objKeyAndFormName;
			TreeNode baseNode = new TreeNode("基本资料",0,0);
			objKeyAndFormName  = new clsKeyAndFormName("S1","","");
			baseNode.Tag = objKeyAndFormName;
			TreeNode baseNodeChild;
			TreeNode childNodeChild;
			TreeNode ccNodeChild;

			#region 基本资料

			baseNodeChild = new TreeNode("住院号",0,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","基本资料>>住院号","(re.INPATIENTID_CHR<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("姓名",0,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","基本资料>>姓名","(pa.LASTNAME_VCHR<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("年龄",0,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","基本资料>>年龄","("+clsDatabaseSQLConvert.s_strGetAgeSQL("pa.BIRTH_DAT")+"<CONDITION>)","INT");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("性别",0,3);
            baseNodeChild.Tag = m_objGetDateSearchesType("", "基本资料>>性别", "(pa.SEX_CHR<CONDITION>)", "STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("入院日期",0,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","基本资料>>入院日期","(re.INPATIENT_DAT<CONDITION>)","DATE");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("出院日期",0,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","基本资料>>出院日期","(le.MODIFY_DAT<CONDITION>)","DATE");
			baseNode.Nodes.Add(baseNodeChild);

			m_mthSetCanSearchNodeColor(baseNode);
           // m_mthSetToolTips(baseNode);
			m_trvMain.Nodes.Add(baseNode);

			#endregion

			#region 手术资料

			baseNode = new TreeNode("手术资料",1,1);
			objKeyAndFormName = new clsKeyAndFormName("S2","frmOperationRecordDoctor","");
			baseNode.Tag = objKeyAndFormName;

			baseNodeChild = new TreeNode("手术日期",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","手术资料>>手术日期","(ORCD.OperationBeginDate<CONDITION>)","DATE");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("术前诊断",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("txtDiagnoseBeforeOperation","手术资料>>术前诊断","(ORCD.DiagnoseBeforeOperation<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("术后诊断",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("txtDiagnoseAfterOperation","手术资料>>术后诊断","(ORCD.DiagnoseAfterOperation<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("手术名称",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtOperationName","手术资料>>手术名称","(ORCD.OperationName<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("手术经过",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("txtOperationProcess","手术资料>>手术经过","(ORCD.OperationProcess<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("手术医师",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","手术资料>>手术医师","(ORCD.OperationDoctor<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("助手",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","手术资料>>助手","(ORCD.Assistant<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("护士",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","手术资料>>护士","(ORCD.Nurse<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("麻醉者",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","手术资料>>麻醉者","(ORCD.Anaesther<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("病理所见",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("txtPathology","手术资料>>病理所见","(ORCD.Pathology<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("麻醉前用药(前晚)",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("txtUseDrugLastNight","手术资料>>麻醉前用药(前晚)","(ORCD.AnaesthesiaBeforeOperation<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("麻醉前用药(术日)",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("txtUseDragOnDay","手术资料>>麻醉前用药(术日)","(ORCD.AnaesthesiaInOperation<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("麻醉种类及用量",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("txtCategoryDosage","手术资料>>麻醉种类及用量","(ORCD.AnaesthesiaCategoryDosage<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("手术期间输液(输血)",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("txtInLiquid","手术资料>>手术期间输液(输血)","(ORCD.InLiquid<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("引流物或填充物",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("txtOutFlow","手术资料>>引流物或填充物","(ORCD.OutFlow<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("标本肉眼所见或特殊记录",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("txtSampleOrExtra","手术资料>>标本肉眼所见或特殊记录","(ORCD.SampleOrExtraRecord<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("术后总结与讲评意见",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("txtSummary","手术资料>>术后总结与讲评意见","(ORCD.SummaryAfterOperation<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("记录者姓名",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","手术资料>>记录者姓名","(ORD.CreateUserID in (select EmployeeID from EmployeeBaseInfo where FirstName<CONDITION>))","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("记录者ID",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","手术资料>>记录者ID","(ORD.CreateUserID<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("记录日期",1,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","手术资料>>记录日期","(ORD.CreateDate<CONDITION>)","DATE");
			baseNode.Nodes.Add(baseNodeChild);

			m_mthSetCanSearchNodeColor(baseNode);
            //m_mthFoundAndSetTemplate2Node(baseNode,"frmOperationRecordDoctor");
            //m_mthSetToolTips(baseNode);
			m_trvMain.Nodes.Add(baseNode);

			#endregion

			#region 住院病历资料
			baseNode = new TreeNode("住院病历资料",2,2);
			objKeyAndFormName  = new clsKeyAndFormName("S3","frmInPatientCaseHistory","");
			baseNode.Tag = objKeyAndFormName;

			baseNodeChild = new TreeNode("主诉",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtMainDescription","住院病历资料>>主诉","(IPHC.MainDescription<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("现病史",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtCurrentStatus","住院病历资料>>现病史","(IPHC.CurrentStatus<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("既往史",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtBeforetimeStatus","住院病历资料>>既往史","(IPHC.BeforetimeStatus<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("个人史",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtOwnHistory","住院病历资料>>个人史","(IPHC.OwnHistory<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("家族史",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtFamilyHistory","住院病历资料>>家族史","(IPHC.FamilyHistory<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("初潮年龄",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","住院病历资料>>初潮年龄","(IPHC.FirstCatamenia<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("月经周期",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","住院病历资料>>月经周期","(IPHC.CatameniaCycle<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("月经情况",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtCatameniaHistory","住院病历资料>>月经情况","(IPHC.CatameniaCase<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("月经婚姻史",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtMarriageHistory","住院病历资料>>月经婚姻史","(IPHC.MarriageHistory<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("体温",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","住院病历资料>>体温","(IPHC.Temperature<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("脉搏",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","住院病历资料>>脉搏","(IPHC.Pulse<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("呼吸",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","住院病历资料>>呼吸","(IPHC.Breath<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("血压(收缩压)",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","住院病历资料>>血压(收缩压)","(IPHC.Sys<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("血压(舒张压)",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","住院病历资料>>血压(舒张压)","(IPHC.Dia<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("体格检查",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtMedical","住院病历资料>>体格检查","(IPHC.Medical<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("专科检查",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtProfessionalCheck","住院病历资料>>专科检查","(IPHC.ProfessionalCheck<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("辅助检查",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtLabCheck","住院病历资料>>辅助检查","(IPHC.LabCheck<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("入院诊断",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtPrimaryDiagnose","住院病历资料>>入院诊断","(IPH.PrimaryDiagnoseAll<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("陈述者",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","住院病历资料>>陈述者","(IPH.Representor<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("可靠度",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","住院病历资料>>可靠度","(IPH.Credibility<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("记录者",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","住院病历资料>>记录者","(IPH.CreateUserID in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("记录者ID",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","住院病历资料>>记录者ID","(IPH.CreateUserID<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("记录日期",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","住院病历资料>>记录日期","(IPH.CreateDate<CONDITION>)","DATE");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("包含图片",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","住院病历资料>>包含图片","((select count(*) from InPatientCaseHistory_Picture where inpatientid = IPH.inpatientid)<CONDITION>)","BOOL");
			baseNode.Nodes.Add(baseNodeChild);

			m_mthSetCanSearchNodeColor(baseNode);
            //m_mthFoundAndSetTemplate2Node(baseNode,"frmInPatientCaseHistory");
            //m_mthSetToolTips(baseNode);
			m_trvMain.Nodes.Add(baseNode);
			#endregion

			#region 住院病案首页
            if (StaticObject::clsEMR_StaticObject.s_StrCurrentHospitalNO != "450101001")//NOT南宁
			{
				#region 
				baseNode = new TreeNode("住院病案首页",2,2);
				objKeyAndFormName  = new clsKeyAndFormName("S5","frmInHospitalMainRecord","");
				baseNode.Tag = objKeyAndFormName;

				baseNodeChild = new TreeNode("门(急)诊诊断",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtDiagnosis","住院病案首页>>门诊（急）诊断","(IHMC.DIAGNOSIS<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("入院诊断",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtInHospitalDiagnosis","住院病案首页>>入院诊断","(IHMC.INHOSPITALDIAGNOSIS<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("门诊（急）医生ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>门诊（急）医生","(IHMC.DOCTOR<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("门诊（急）医生",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>门诊（急）医生","(IHMC.DOCTOR in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("入院后确诊日期",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>入院后确诊日期","(IHMC.CONFIRMDIAGNOSISDATE<CONDITION>)","DATE");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("入院时情况",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("危",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>入院时情况>>危","((select count(CONDICTIONWHENIN) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CONDICTIONWHENIN=0)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("急",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>入院时情况>>急","((select count(CONDICTIONWHENIN) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CONDICTIONWHENIN=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("一般",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>入院时情况>>一般","((select count(CONDICTIONWHENIN) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CONDICTIONWHENIN=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("主要诊断",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtMainDiagnosis","住院病案首页>>主要诊断","(IHMC.MAINDIAGNOSIS<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("其它诊断",2,3);
				objKeyAndFormName  = new clsKeyAndFormName("S5","frmInHospitalMainRecord","");
				baseNodeChild.Tag = objKeyAndFormName;
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("诊断内容",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>其它诊断>>诊断内容","(SS1.DIAGNOSISDESC<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("治疗情况",2,3);
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("治愈",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>其它诊断>>治疗情况>>治愈","((select count(CONDITIONSEQ) from IHMainRecord_OtherDiagnosis where inpatientid = SS1.inpatientid and SS1.inpatientdate = inpatientdate and SS1.opendate =opendate and CONDITIONSEQ=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("好转",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>其它诊断>>治疗情况>>好转","((select count(CONDITIONSEQ) from IHMainRecord_OtherDiagnosis where inpatientid = SS1.inpatientid and SS1.inpatientdate = inpatientdate and SS1.opendate =opendate and CONDITIONSEQ=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("未愈",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>其它诊断>>治疗情况>>未愈","((select count(CONDITIONSEQ) from IHMainRecord_OtherDiagnosis where inpatientid = SS1.inpatientid and SS1.inpatientdate = inpatientdate and SS1.opendate =opendate and CONDITIONSEQ=2)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("死亡",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>其它诊断>>治疗情况>>死亡","((select count(CONDITIONSEQ) from IHMainRecord_OtherDiagnosis where inpatientid = SS1.inpatientid and SS1.inpatientdate = inpatientdate and SS1.opendate =opendate and CONDITIONSEQ=3)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("其他",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>其它诊断>>治疗情况>>其他","((select count(CONDITIONSEQ) from IHMainRecord_OtherDiagnosis where inpatientid = SS1.inpatientid and SS1.inpatientdate = inpatientdate and SS1.opendate =opendate and CONDITIONSEQ=4)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				baseNodeChild = new TreeNode("出院情况",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("治愈",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>其它诊断>>出院情况>>治愈","((select count(MAINCONDITIONSEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and MAINCONDITIONSEQ=0)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("好转",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>其它诊断>>出院情况>>好转","((select count(MAINCONDITIONSEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and MAINCONDITIONSEQ=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("未愈",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>其它诊断>>出院情况>>未愈","((select count(MAINCONDITIONSEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and MAINCONDITIONSEQ=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("死亡",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>其它诊断>>出院情况>>死亡","((select count(MAINCONDITIONSEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and MAINCONDITIONSEQ=3)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("其他",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtICD_10OfMain","住院病案首页>>其它诊断>>出院情况>>其他","(IHMC.ICD_10OFMAIN<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("医院感染名称",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtInfectionDiagnosis","住院病案首页>>医院感染名称","(IHMC.INFECTIONDIAGNOSIS<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("感染治疗情况",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("治愈",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>感染治疗情况>>治愈","((select count(INFECTIONCONDICTIONSEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and INFECTIONCONDICTIONSEQ=0)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("好转",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>感染治疗情况>>好转","((select count(INFECTIONCONDICTIONSEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and INFECTIONCONDICTIONSEQ=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("未愈",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>感染治疗情况>>未愈","((select count(INFECTIONCONDICTIONSEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and INFECTIONCONDICTIONSEQ=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("死亡",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>感染治疗情况>>死亡","((select count(INFECTIONCONDICTIONSEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and INFECTIONCONDICTIONSEQ=3)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("其他",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtICD_10OfInfection","住院病案首页>>感染治疗情况>>其他","(IHMC.ICD_10OFINFECTION<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("病理诊断",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtPathologyDiagnosis","住院病案首页>>病理诊断","(IHMC.PATHOLOGYDIAGNOSIS<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("损伤、中毒的外部因素",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtScacheSource","住院病案首页>>损伤、中毒的外部因素","(IHMC.SCACHESOURCE<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("药物过敏",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtSensitive","住院病案首页>>药物过敏","(IHMC.SENSITIVE<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("检验",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("HbsAg",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtHbsAg","住院病案首页>>检验>>HbsAg","(IHMC.HBSAG<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("HCV-Ab",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtHCV_Ab","住院病案首页>>检验>>HCV-Ab","(IHMC.HCV_AB<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("HIV_Ab",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtHIV_Ab","住院病案首页>>检验>>HIV-Ab","(IHMC.HIV_AB<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("诊断符合情况",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("门诊与出院",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtAccordWithOutHospital","住院病案首页>>诊断符合情况>>门诊与出院","(IHMC.ACCORDWITHOUTHOSPITAL<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("入院与出院",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtAccordInWithOut","住院病案首页>>诊断符合情况>>入院与出院","(IHMC.ACCORDINWITHOUT<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("术前与术后",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtAccordBeforeOperationWithAfter","住院病案首页>>诊断符合情况>>术前与术后","(IHMC.ACCORDBEFOREOPERATIONWITHAFTER<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("临床与病理",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtAccordClinicWithPathology","住院病案首页>>诊断符合情况>>临床与病理","(IHMC.ACCORDCLINICWITHPATHOLOGY<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("放射与病理",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtAccordRadiateWithPathology","住院病案首页>>诊断符合情况>>放射与病理","(IHMC.ACCORDRADIATEWITHPATHOLOGY<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("抢救次数",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtSalveTimes","住院病案首页>>抢救次数","(IHMC.SALVETIMES<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("抢救成功次数",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtSalveSuccess","住院病案首页>>抢救成功次数","(IHMC.SALVESUCCESS<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("科主任ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>科主任","(IHMC.DIRECTORDT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("科主任",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>科主任","(IHMC.DIRECTORDT in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("主（副主）任医师ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>主（副主）任医师","(IHMC.SUBDIRECTORDT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("主（副主）任医师",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>主（副主）任医师","(IHMC.SUBDIRECTORDT in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("主治医师ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>主治医师","(IHMC.DT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("主治医师",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>主治医师","(IHMC.DT in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("住院医师ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>住院医师","(IHMC.INHOSPITALDT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("住院医师",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>住院医师","(IHMC.INHOSPITALDT in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("进修医师ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>进修医师","(IHMC.ATTENDINFORADVANCESSTUDYDT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("进修医师",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>进修医师","(IHMC.ATTENDINFORADVANCESSTUDYDT in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("研究生实习医师ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>研究生实习医师","(IHMC.GRADUATESTUDENTINTERN<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("研究生实习医师",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>研究生实习医师","(IHMC.GRADUATESTUDENTINTERN in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("实习医师",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>实习医师","(IHMC.INTERN<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("编码员ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>编码员","(IHMC.CODER<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("编码员",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>编码员","(IHMC.CODER in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("病案质量",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("甲",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>病案质量>>甲","((select count(QUALITY) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and QUALITY=0)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("乙",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>病案质量>>乙","((select count(QUALITY) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and QUALITY=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("丙",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>病案质量>>丙","((select count(QUALITY) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and QUALITY=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("质控医师ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>质控医师","(IHMC.QCDT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("质控医师",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>质控医师","(IHMC.QCDT in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("质控护士ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>质控护士","(IHMC.QCNURSE<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("质控护士",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>质控护士","(IHMC.QCNURSE in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);
			
				baseNodeChild = new TreeNode("质控日期",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>质控日期","(IHMC.QCTIME<CONDITION>)","DATE");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("手术情况",2,3);
				objKeyAndFormName  = new clsKeyAndFormName("S6","frmInHospitalMainRecord","");
				baseNodeChild.Tag = objKeyAndFormName;
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("手术、操作编码",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>手术、操作编码","(SS2.OPERATIONID<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("手术、操作日期",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>手术、操作日期","(SS2.OPERATIONDATE<CONDITION>)","DATE");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("手术、操作名称",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>手术、操作名称","(SS2.OPERATIONNAME<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("术者ID",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>术者","(SS2.OPERATOR<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("术者",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>术者","(SS2.OPERATOR in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("Ⅰ助ID",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>Ⅰ助","(SS2.ASSISTANT1<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("Ⅰ助",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>Ⅰ助","(SS2.ASSISTANT1 in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("Ⅱ助ID",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>Ⅱ助","(SS2.ASSISTANT2<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("Ⅱ助",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>Ⅱ助","(SS2.ASSISTANT2 in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("麻醉方式ID",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>麻醉方式","(SS2.AANAESTHESIAMODEID<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("麻醉方式",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>麻醉方式","(SS2.AANAESTHESIAMODEID in (select AANAESTHESIAMODEID from AnaesthesiaMode where AnaesthesiaModeName<CONDITION>))","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("切口愈合等级",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>切口愈合等级","(SS2.CUTLEVEL<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("麻醉医师ID",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>麻醉医师","(SS2.ANAESTHETIST<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("麻醉医师",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>麻醉医师","(SS2.ANAESTHETIST in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("产科分娩婴儿记录表",2,3);
				objKeyAndFormName  = new clsKeyAndFormName("S7","frmInHospitalMainRecord","");
				baseNodeChild.Tag = objKeyAndFormName;
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("男性",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>产科分娩婴儿记录表>>男性","((select count(MALE) from inhospitalmainrecord_baby where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and MALE=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("女性",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>产科分娩婴儿记录表>>女性","((select count(FEMALE) from inhospitalmainrecord_baby where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and FEMALE=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("活产",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>产科分娩婴儿记录表>>活产","((select count(LIVEBORN) from inhospitalmainrecord_baby where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and LIVEBORN=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("死产",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>产科分娩婴儿记录表>>死产","((select count(DIEBORN) from inhospitalmainrecord_baby where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and DIEBORN=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("死胎",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>产科分娩婴儿记录表>>死胎","((select count(DIENOTBORN) from inhospitalmainrecord_baby where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and DIENOTBORN=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("婴儿体重",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>产科分娩婴儿记录表>>婴儿体重","(SS3.WEIGHT<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("死亡",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>产科分娩婴儿记录表>>死亡","((select count(DIE) from inhospitalmainrecord_baby where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and DIE=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("转科",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>产科分娩婴儿记录表>>转科","((select count(CHANGEDEPARTMENT) from inhospitalmainrecord_baby where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CHANGEDEPARTMENT=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("出院",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>产科分娩婴儿记录表>>出院","((select count(OUTHOSPITAL) from inhospitalmainrecord_baby where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and OUTHOSPITAL=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("自然",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>产科分娩婴儿记录表>>自然","((select count(NATURALCONDICTION) from inhospitalmainrecord_baby where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and NATURALCONDICTION=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("Ⅰ度窒息",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>产科分娩婴儿记录表>>Ⅰ度窒息","((select count(SUFFOCATE1) from inhospitalmainrecord_baby where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and SUFFOCATE1=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("Ⅱ度窒息",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>产科分娩婴儿记录表>>Ⅱ度窒息","((select count(SUFFOCATE2) from inhospitalmainrecord_baby where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and SUFFOCATE2=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("医院感染次数",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>产科分娩婴儿记录表>>医院感染次数","(SS3.INFECTIONTIMES<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("主要医院感染名称",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>产科分娩婴儿记录表>>主要医院感染名称","(SS3.INFECTIONNAME<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("抢救次数",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>产科分娩婴儿记录表>>抢救次数","(SS3.SALVETIMES<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("抢救成功次数",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>产科分娩婴儿记录表>>抢救成功次数","(SS3.SALVESUCCESSTIMES<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("肿瘤专科病人治疗记录表",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("放疗方式",2,3);			
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("根治性",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>放疗方式>>根治性","((select count(RTMODESEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and RTMODESEQ=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("姑息性",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>放疗方式>>姑息性","((select count(RTMODESEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and RTMODESEQ=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("辅助性",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>放疗方式>>辅助性","((select count(RTMODESEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and RTMODESEQ=2)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("放疗装置",2,3);			
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("钴",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>放疗装置>>钴","((select count(RTCO) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and RTCO=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("直加",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>放疗装置>>直加","((select count(RTACCELERATOR) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and RTACCELERATOR=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("X线",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>放疗装置>>X线","((select count(RTX_RAY) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and RTX_RAY=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("后装",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>放疗装置>>后装","((select count(RTLACUNA) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and RTLACUNA=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("放疗程式",2,3);			
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("连续",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>放疗程式>>连续","((select count(RTRULESEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and RTRULESEQ=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("间断",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>放疗程式>>间断","((select count(RTRULESEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and RTRULESEQ=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("分段",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>放疗程式>>分段","((select count(RTRULESEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and RTRULESEQ=2)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("原发灶",2,3);			
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("首次",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>原发灶>>首次","((select count(ORIGINALDISEASESEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and ORIGINALDISEASESEQ=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("复次",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>原发灶>>复次","((select count(ORIGINALDISEASESEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and ORIGINALDISEASESEQ=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("剂量",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>原发灶>>剂量","(IHMC.ORIGINALDISEASEGY<CONDITION>)","STRING");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("开始时间",0,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>原发灶>>开始时间","(IHMC.ORIGINALDISEASEBEGINDATE<CONDITION>)","DATE");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("结束时间",0,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>原发灶>>结束时间","(IHMC.ORIGINALDISEASEENDDATE<CONDITION>)","DATE");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("区域淋巴结",2,3);			
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("首次",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>区域淋巴结>>首次","((select count(LYMPHSEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and LYMPHSEQ=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("复次",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>区域淋巴结>>复次","((select count(LYMPHSEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and LYMPHSEQ=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("剂量",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>区域淋巴结>>剂量","(IHMC.LYMPHGY<CONDITION>)","STRING");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("开始时间",0,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>区域淋巴结>>开始时间","(IHMC.LYMPHBEGINDATE<CONDITION>)","DATE");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("结束时间",0,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>区域淋巴结>>结束时间","(IHMC.LYMPHENDDATE<CONDITION>)","DATE");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("转移灶",2,3);			
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("剂量",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>转移灶>>剂量","(IHMC.METASTASISGY<CONDITION>)","STRING");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("开始时间",0,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>转移灶>>开始时间","(IHMC.METASTASISBEGINDATE<CONDITION>)","DATE");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("结束时间",0,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>转移灶>>结束时间","(IHMC.METASTASISENDDATE<CONDITION>)","DATE");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("化疗方式",2,3);			
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("根治性",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗方式>>根治性","((select count(CHEMOTHERAPYMODESEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CHEMOTHERAPYMODESEQ=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("姑息性",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗方式>>姑息性","((select count(CHEMOTHERAPYMODESEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CHEMOTHERAPYMODESEQ=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("新辅助性",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗方式>>新辅助性","((select count(CHEMOTHERAPYMODESEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CHEMOTHERAPYMODESEQ=2)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("辅助性",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗方式>>辅助性","((select count(CHEMOTHERAPYMODESEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CHEMOTHERAPYMODESEQ=3)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("新药",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗方式>>新药","((select count(CHEMOTHERAPYMODESEQ) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CHEMOTHERAPYMODESEQ=4)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("化疗方法",2,3);			
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("全化",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗方法>>全化","((select count(CHEMOTHERAPYWHOLEBODY) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CHEMOTHERAPYWHOLEBODY=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("半化",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗方法>>半化","((select count(CHEMOTHERAPYLOCAL) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CHEMOTHERAPYLOCAL=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("A插管",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗方法>>A插管","((select count(CHEMOTHERAPYINTUBATE) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CHEMOTHERAPYINTUBATE=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("胸腔注",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗方法>>胸腔注","((select count(CHEMOTHERAPYTHORAX) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CHEMOTHERAPYTHORAX=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("腹腔注",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗方法>>腹腔注","((select count(CHEMOTHERAPYABDOMEN) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CHEMOTHERAPYABDOMEN=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("髓注",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗方法>>髓注","((select count(CHEMOTHERAPYSPINAL) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CHEMOTHERAPYSPINAL=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("其他试用",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗方法>>其他试用","((select count(CHEMOTHERAPYOTHERTRY) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CHEMOTHERAPYOTHERTRY=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("其他",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗方法>>其他","((select count(CHEMOTHERAPYOTHER) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CHEMOTHERAPYOTHER=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("化疗用药及疗效",2,3);				
				objKeyAndFormName  = new clsKeyAndFormName("S8","frmInHospitalMainRecord","");
				childNodeChild.Tag = objKeyAndFormName;
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("日期",0,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗用药及疗效>>日期","(SS4.CHEMOTHERAPYDATE<CONDITION>)","DATE");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("药品名称(剂量)",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗用药及疗效>>药品名称(剂量)","(SS4.MEDICINENAME<CONDITION>)","STRING");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("疗程",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗用药及疗效>>疗程","(SS4.PERIOD<CONDITION>)","STRING");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("疗效消失(CR)",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗用药及疗效>>疗效消失(CR)","((select count(FIELD_CR) from IHMainRecord_Chemotherapy where inpatientid = SS4.inpatientid and SS4.inpatientdate = inpatientdate and SS4.opendate =opendate and FIELD_CR=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("显效(PR)",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗用药及疗效>>显效(PR)","((select count(FIELD_PR) from IHMainRecord_Chemotherapy where inpatientid = SS4.inpatientid and SS4.inpatientdate = inpatientdate and SS4.opendate =opendate and FIELD_PR=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("好转(MR)",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗用药及疗效>>好转(MR)","((select count(FIELD_MR) from IHMainRecord_Chemotherapy where inpatientid = SS4.inpatientid and SS4.inpatientdate = inpatientdate and SS4.opendate =opendate and FIELD_MR=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("不变(S)",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗用药及疗效>>不变(S)","((select count(FIELD_S) from IHMainRecord_Chemotherapy where inpatientid = SS4.inpatientid and SS4.inpatientdate = inpatientdate and SS4.opendate =opendate and FIELD_S=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("恶化(P)",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗用药及疗效>>恶化(P)","((select count(FIELD_P) from IHMainRecord_Chemotherapy where inpatientid = SS4.inpatientid and SS4.inpatientdate = inpatientdate and SS4.opendate =opendate and FIELD_P=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("未定(NA)",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>肿瘤专科病人治疗记录表>>化疗用药及疗效>>未定(NA)","((select count(FIELD_NA) from IHMainRecord_Chemotherapy where inpatientid = SS4.inpatientid and SS4.inpatientdate = inpatientdate and SS4.opendate =opendate and FIELD_NA=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				baseNodeChild = new TreeNode("住院费用总计",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtTotalAmt","住院病案首页>>住院费用总计","(IHMC.TOTALAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("床费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtBedAmt","住院病案首页>>床费","(IHMC.BEDAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("护理费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtNurseAmt","住院病案首页>>护理费","(IHMC.NURSEAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("西药费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtWMAmt","住院病案首页>>西药费","(IHMC.WMAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("中成药费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtCMFinishedAmt","住院病案首页>>中成药费","(IHMC.CMFINISHEDAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("中草药费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtCMSemiFinishedAmt","住院病案首页>>中草药费","(IHMC.CMSEMIFINISHEDAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("放射费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtRadiationAmt","住院病案首页>>放射费","(IHMC.RADIATIONAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("化验费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtAssayAmt","住院病案首页>>化验费","(IHMC.ASSAYAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("输氧费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtO2Amt","住院病案首页>>输氧费","(IHMC.O2AMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("输血费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtBloodAmt","住院病案首页>>输血费","(IHMC.BLOODAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("诊疗费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtTreatmentAmt","住院病案首页>>诊疗费","(IHMC.TREATMENTAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("手术费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtOperationAmt","住院病案首页>>手术费","(IHMC.OPERATIONAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("接生费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtDeliveryChildAmt","住院病案首页>>接生费","(IHMC.DELIVERYCHILDAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("检查费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtCheckAmt","住院病案首页>>检查费","(IHMC.CHECKAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("麻醉费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtAnaethesiaAmt","住院病案首页>>麻醉费","(IHMC.ANAETHESIAAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("婴儿费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtBabyAmt","住院病案首页>>婴儿费","(IHMC.BABYAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("陪床费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtAccompanyAmt","住院病案首页>>陪床费","(IHMC.ACCOMPANYAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("其他费1",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtOtherAmt1","住院病案首页>>其他费1","(IHMC.OTHERAMT1<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("其他费2",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtOtherAmt2","住院病案首页>>其他费2","(IHMC.OTHERAMT2<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("其他费3",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtOtherAmt3","住院病案首页>>其他费3","(IHMC.OTHERAMT3<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("尸检",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("是",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>尸检>>是","((select count(CORPSECHECK) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CORPSECHECK=0)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("否",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>尸检>>否","((select count(CORPSECHECK) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and CORPSECHECK=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("手术、治疗、检查、诊断为本院第一例",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("是",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术、治疗、检查、诊断为本院第一例>>是","((select count(FIRSTCASE) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and FIRSTCASE=0)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("否",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术、治疗、检查、诊断为本院第一例>>否","((select count(FIRSTCASE) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and FIRSTCASE=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("示范病例",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("是",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>示范病例>>是","((select count(MODELCASE) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and MODELCASE=0)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("否",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>示范病例>>否","((select count(MODELCASE) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and MODELCASE=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("随诊",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("是",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>随诊>>是","((select count(FOLLOW) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and FOLLOW=0)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("否",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>随诊>>否","((select count(FOLLOW) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and FOLLOW=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("随诊期限",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("周",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtFollow_Week","住院病案首页>>随诊期限>>周","(IHMC.FOLLOW_WEEK<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("月",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtFollow_Month","住院病案首页>>随诊期限>>月","(IHMC.FOLLOW_MONTH<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("年",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtFollow_Year","住院病案首页>>随诊期限>>年","(IHMC.FOLLOW_YEAR<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("血型",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtBloodType","住院病案首页>>血型","(IHMC.BLOODTYPE<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("RH",2,3);			
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("阴",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>RH>>阴","((select count(BLOODRH) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and BLOODRH=0)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("阳",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>RH>>阳","((select count(BLOODRH) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and BLOODRH=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("输血反应",2,3);			
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("有",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>输血反应>>有","((select count(BLOODTRANSACTOIN) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and BLOODTRANSACTOIN=0)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("无",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>输血反应>>无","((select count(BLOODTRANSACTOIN) from INHOSPITALMAINRECORD_CONTENT where inpatientid = IHMC.inpatientid and IHMC.inpatientdate = inpatientdate and IHMC.opendate =opendate and BLOODTRANSACTOIN=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("输血品种",2,3);			
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("红细胞数量",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtRBC","住院病案首页>>输血品种>>红细胞数量","(IHMC.RBC<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("血小板数量",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtPLT","住院病案首页>>输血品种>>血小板数量","(IHMC.PLT<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("血浆数量",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtPlasm","住院病案首页>>输血品种>>血浆数量","(IHMC.PLASM<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("全血数量",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtWholeBlood","住院病案首页>>输血品种>>全血数量","(IHMC.WHOLEBLOOD<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("其他",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>输血品种>>其他","(IHMC.OTHERBLOOD<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("院际会诊次数",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtConsultation","住院病案首页>>院际会诊次数","(IHMC.CONSULTATION<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("远程会诊",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtLongDistanctConsultation","住院病案首页>>远程会诊","(IHMC.LONGDISTANCTCONSULTATION<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("护理等级",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("特级",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtTOPLevel","住院病案首页>>护理等级>>特级","(IHMC.TOPLEVEL<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("Ⅰ级",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtNurseLevelI","住院病案首页>>护理等级>>Ⅰ级","(IHMC.NURSELEVELI<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("Ⅱ级",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtNurseLevelII","住院病案首页>>护理等级>>Ⅱ级","(IHMC.NURSELEVELII<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("Ⅲ级",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtNurseLevelIII","住院病案首页>>护理等级>>Ⅲ级","(IHMC.NURSELEVELIII<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("重症监护",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtNurseLevelII","住院病案首页>>护理等级>>重症监护","(IHMC.ICU<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("特殊护理",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtNurseLevelIII","住院病案首页>>护理等级>>特殊护理","(IHMC.SPECIALNURSE<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				m_mthSetCanSearchNodeColor(baseNode);
                //m_mthFoundAndSetTemplate2Node(baseNode,"frmInHospitalMainRecord");
                //m_mthSetToolTips(baseNode);
				m_trvMain.Nodes.Add(baseNode);
				#endregion
			}
			else
			{
				#region 住院病案首页(广西)
				baseNode = new TreeNode("住院病案首页",2,2);
				objKeyAndFormName  = new clsKeyAndFormName("S9","frmInHospitalMainRecord_GX","");
				baseNode.Tag = objKeyAndFormName;

				baseNodeChild = new TreeNode("入院时情况",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("危",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>入院时情况>>危","((select count(CONDICTIONWHENIN) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and CONDICTIONWHENIN=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("急",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>入院时情况>>急","((select count(CONDICTIONWHENIN) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and CONDICTIONWHENIN=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("一般",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>入院时情况>>一般","((select count(CONDICTIONWHENIN) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and CONDICTIONWHENIN=3)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("入院后确诊日期",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>入院后确诊日期","(IHMC.CONFIRMDIAGNOSISDATE<CONDITION>)","DATE");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("门(急)诊诊断",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("诊断内容",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("txtDiagnosis","住院病案首页>>门诊（急）诊断","(IHMC.DIAGNOSIS<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("统计码",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("m_txtSTATCODEOFDIAGNOSIS","住院病案首页>>门(急)诊诊断统计码","(IHMC.STATCODEOFDIAGNOSIS<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("ICD码",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("m_txtICD_10OFDIAGNOSIS","住院病案首页>>门(急)诊诊断ICD码","(IHMC.ICD_10OFDIAGNOSIS<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

                baseNodeChild = new TreeNode("入院诊断", 2, 3);
                objKeyAndFormName = new clsKeyAndFormName("S15", "frmInHospitalMainRecord_GX", "");
                baseNodeChild.Tag = objKeyAndFormName;
                baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("诊断内容",2,3);
                childNodeChild.Tag = m_objGetDateSearchesType("txtInHospitalDiagnosis", "住院病案首页>>入院诊断", "(IHID.DIAGNOSISDESC<CONDITION>)", "STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("统计码",2,3);
                childNodeChild.Tag = m_objGetDateSearchesType("m_txtSTATCODEOFINHOSPITALDIA", "住院病案首页>>入院诊断统计码", "(IHID.STATCODE<CONDITION>)", "STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("ICD码",2,3);
                childNodeChild.Tag = m_objGetDateSearchesType("m_txtICD_10OFINHOSPITALDIA", "住院病案首页>>入院诊断ICD码", "(IHID.ICD10<CONDITION>)", "STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("出院主要诊断",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("诊断内容",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("m_txtMainDiagnosis","住院病案首页>>出院主要诊断","(IHMC.MAINDIAGNOSIS<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("疗效",2,3);
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("治愈",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>出院主要诊断>>治愈","((select count(MAINCONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and MAINCONDITIONSEQ=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("好转",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>出院主要诊断>>好转","((select count(MAINCONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and MAINCONDITIONSEQ=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("未愈",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>出院主要诊断>>未愈","((select count(MAINCONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and MAINCONDITIONSEQ=2)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("死亡",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>出院主要诊断>>死亡","((select count(MAINCONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and MAINCONDITIONSEQ=3)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("其他",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>出院主要诊断>>其他","(IHMC.OTHERMAINCONDITION<CONDITION>)","STRING");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("正常分娩",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>出院主要诊断>>正常分娩","((select count(MAINCONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and MAINCONDITIONSEQ=5)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("统计码",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("m_txtSTATCODEOFMAIN","住院病案首页>>出院主要诊断统计码","(IHMC.STATCODEOFMAIN<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("ICD码",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("m_txtICD_10OFMAIN","住院病案首页>>出院主要诊断ICD码","(IHMC.ICD_10OFMAIN<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("出院其他诊断",2,3);			
				objKeyAndFormName  = new clsKeyAndFormName("S10","frmInHospitalMainRecord_GX","");
				baseNodeChild.Tag = objKeyAndFormName;
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("诊断内容",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>出院其他诊断","(IHMD.DIAGNOSISDESC<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("疗效",2,3);
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("治愈",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>出院其他诊断>>治愈","((select count(CONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXOD where EMR_SEQ=IHMC.EMR_SEQ and CONDITIONSEQ=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("好转",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>出院其他诊断>>好转","((select count(CONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXOD where EMR_SEQ=IHMC.EMR_SEQ and CONDITIONSEQ=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("未愈",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>出院其他诊断>>未愈","((select count(CONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXOD where EMR_SEQ=IHMC.EMR_SEQ and CONDITIONSEQ=2)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("死亡",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>出院其他诊断>>死亡","((select count(CONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXOD where EMR_SEQ=IHMC.EMR_SEQ and CONDITIONSEQ=3)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("其他",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>出院其他诊断>>其他","(IHMD.OTHERCONDITION<CONDITION>)","STRING");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("正常分娩",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>出院其他诊断>>正常分娩","((select count(CONDITIONSEQ) from T_EMR_INHOSPITALMAINREC_GXOD where EMR_SEQ=IHMC.EMR_SEQ and CONDITIONSEQ=5)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("统计码",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>出院其他诊断统计码","(IHMD.STATCODE<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("ICD码",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>出院其他诊断ICD码","(IHMD.ICD10<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("并发症(含手术麻醉)",2,3);		
				objKeyAndFormName  = new clsKeyAndFormName("S9","frmInHospitalMainRecord_GX","");
				baseNodeChild.Tag = objKeyAndFormName;
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("并发症(含手术麻醉)",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("m_txtCOMPLICATION","住院病案首页>>并发症(含手术麻醉)","(IHMC.COMPLICATION<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("疗效",2,3);
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("治愈",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>并发症(含手术麻醉)>>治愈","((select count(COMPLICATIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and COMPLICATIONSEQ=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("好转",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>并发症(含手术麻醉)>>好转","((select count(COMPLICATIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and COMPLICATIONSEQ=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("未愈",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>并发症(含手术麻醉)>>未愈","((select count(COMPLICATIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and COMPLICATIONSEQ=2)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("死亡",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>并发症(含手术麻醉)>>死亡","((select count(COMPLICATIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and COMPLICATIONSEQ=3)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("其他",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>并发症(含手术麻醉)>>其他","(IHMC.OTHERCOMPLICATION<CONDITION>)","STRING");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("正常分娩",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>并发症(含手术麻醉)>>正常分娩","((select count(COMPLICATIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and COMPLICATIONSEQ=5)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("统计码",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("m_txtSTATCODEOFCOMPLICATION","住院病案首页>>并发症(含手术麻醉)统计码","(IHMC.STATCODEOFCOMPLICATION<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("ICD码",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("m_txtICD_10OFCOMPLICATION","住院病案首页>>并发症(含手术麻醉)ICD码","(IHMC.ICD_10OFCOMPLICATION<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("院内感染名称",2,3);	
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("院内感染名称",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("m_txtINFECTIONDIAGNOSIS","住院病案首页>>院内感染名称","(IHMC.INFECTIONDIAGNOSIS<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("疗效",2,3);
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("治愈",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>院内感染名称>>治愈","((select count(INFECTIONCONDICTIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and INFECTIONCONDICTIONSEQ=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("好转",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>院内感染名称>>好转","((select count(INFECTIONCONDICTIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and INFECTIONCONDICTIONSEQ=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("未愈",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>院内感染名称>>未愈","((select count(INFECTIONCONDICTIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and INFECTIONCONDICTIONSEQ=2)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("死亡",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>院内感染名称>>死亡","((select count(INFECTIONCONDICTIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and INFECTIONCONDICTIONSEQ=3)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("其他",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>院内感染名称>>其他","(IHMC.OTHERINFECTIONCONDICTION<CONDITION>)","STRING");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("正常分娩",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>院内感染名称>>正常分娩","((select count(INFECTIONCONDICTIONSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and INFECTIONCONDICTIONSEQ=5)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("统计码",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("m_txtSTATCODEOFINFECTION","住院病案首页>>院内感染名称统计码","(IHMC.STATCODEOFINFECTION<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("ICD码",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("m_txtICD_10OFINFECTION","住院病案首页>>院内感染名称ICD码","(IHMC.ICD_10OFINFECTION<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("病理诊断",2,3);	
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("诊断内容",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("m_txtPATHOLOGYDIAGNOSIS","住院病案首页>>病理诊断","(IHMC.PATHOLOGYDIAGNOSIS<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("疗效",2,3);
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("治愈",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>病理诊断>>治愈","((select count(PATHOLOGYDIAGNOSISSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and PATHOLOGYDIAGNOSISSEQ=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("好转",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>病理诊断>>好转","((select count(PATHOLOGYDIAGNOSISSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and PATHOLOGYDIAGNOSISSEQ=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("未愈",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>病理诊断>>未愈","((select count(PATHOLOGYDIAGNOSISSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and PATHOLOGYDIAGNOSISSEQ=2)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("死亡",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>病理诊断>>死亡","((select count(PATHOLOGYDIAGNOSISSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and PATHOLOGYDIAGNOSISSEQ=3)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("其他",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>病理诊断>>其他","(IHMC.OTHERPATHOLOGYDIAGNOSIS<CONDITION>)","STRING");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("正常分娩",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>病理诊断>>正常分娩","((select count(PATHOLOGYDIAGNOSISSEQ) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and PATHOLOGYDIAGNOSISSEQ=5)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("统计码",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("m_txtSTATCODEOFPATHOLOGYDIA","住院病案首页>>病理诊断统计码","(IHMC.STATCODEOFPATHOLOGYDIA<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("ICD码",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("m_txtICD_10OFPATHOLOGYDIA","住院病案首页>>病理诊断ICD码","(IHMC.ICD_10OFPATHOLOGYDIA<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("损伤和中毒的外部原因",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("m_txtScacheSource","住院病案首页>>损伤和中毒的外部原因","(IHMC.SCACHESOURCE<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("新五病",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("是",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>新五病>>是","((select count(NEW5DISEASE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and NEW5DISEASE=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("否",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>新五病>>否","((select count(NEW5DISEASE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and NEW5DISEASE=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("二级转诊",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("有",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>二级转诊>>有","((select count(SECONDLEVELTRANSFER) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and SECONDLEVELTRANSFER=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("无",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>二级转诊>>无","((select count(SECONDLEVELTRANSFER) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and SECONDLEVELTRANSFER=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("过敏药物",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("HBsAg",2,3);
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("未做",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>HBsAg>>未做","((select count(HBSAG) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HBSAG=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("阴性",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>HBsAg>>阴性","((select count(HBSAG) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HBSAG=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("阳性",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>HBsAg>>阳性","((select count(HBSAG) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HBSAG=2)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("HCV-Ab",2,3);
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("未做",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>HCV-Ab>>未做","((select count(HCV_AB) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HCV_AB=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("阴性",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>HCV-Ab>>阴性","((select count(HCV_AB) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HCV_AB=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("阳性",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>HCV-Ab>>阳性","((select count(HCV_AB) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HCV_AB=2)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("HIV-Ab",2,3);
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("未做",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>HIV-Ab>>未做","((select count(HIV_AB) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HIV_AB=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("阴性",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>HIV-Ab>>阴性","((select count(HIV_AB) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HIV_AB=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("阳性",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>HIV-Ab>>阳性","((select count(HIV_AB) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HIV_AB=2)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				baseNodeChild = new TreeNode("手术情况",2,3);
				objKeyAndFormName  = new clsKeyAndFormName("S11","frmInHospitalMainRecord_GX","");
				baseNodeChild.Tag = objKeyAndFormName;
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("手术、操作日期",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>手术、操作日期","(IHMO.OPERATIONDATE<CONDITION>)","DATE");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("手术、操作编码",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>手术、操作编码","(IHMO.OPERATIONID<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("手术、操作名称",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>手术、操作名称","(IHMO.OPERATIONNAME<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("术者ID",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>术者","(IHMO.OPERATOR<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("术者",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>术者","(IHMO.OPERATOR in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("Ⅰ助ID",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>Ⅰ助","(IHMO.ASSISTANT1<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("Ⅰ助",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>Ⅰ助","(IHMO.ASSISTANT1 in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("Ⅱ助ID",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>Ⅱ助","(IHMO.ASSISTANT2<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("Ⅱ助",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>Ⅱ助","(IHMO.ASSISTANT2 in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("麻醉方式ID",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>麻醉方式","(IHMO.AANAESTHESIAMODEID<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("麻醉方式",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>麻醉方式","(IHMO.AANAESTHESIAMODEID in (select AANAESTHESIAMODEID from AnaesthesiaMode where AnaesthesiaModeName<CONDITION>))","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("切口愈合等级",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>切口愈合等级","(IHMO.CUTLEVEL<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("麻醉医师ID",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>麻醉医师","(IHMO.ANAESTHETIST<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("麻醉医师",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术情况>>麻醉医师","(IHMO.ANAESTHETIST in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("新生儿疾病诊断",2,3);		
				objKeyAndFormName  = new clsKeyAndFormName("S9","frmInHospitalMainRecord_GX","");
				baseNodeChild.Tag = objKeyAndFormName;
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("诊断内容1",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("m_txtNEONATEDISEASE1","住院病案首页>>新生儿疾病诊断1","(IHMC.NEONATEDISEASE1<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("诊断内容2",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("m_txtNEONATEDISEASE2","住院病案首页>>新生儿疾病诊断2","(IHMC.NEONATEDISEASE2<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("诊断内容3",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("m_txtNEONATEDISEASE3","住院病案首页>>新生儿疾病诊断3","(IHMC.NEONATEDISEASE3<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("诊断内容4",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("m_txtNEONATEDISEASE4","住院病案首页>>新生儿疾病诊断4","(IHMC.NEONATEDISEASE4<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("抢救次数",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("m_txtSALVETIMES","住院病案首页>>抢救次数","(IHMC.SALVETIMES<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("抢救成功次数",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("m_txtSALVESUCCESS","住院病案首页>>抢救成功次数","(IHMC.SALVESUCCESS<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("随诊",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("是",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>随诊>>是","((select count(HASREMIND) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HASREMIND=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("否",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>随诊>>否","((select count(HASREMIND) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and HASREMIND=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("随诊期限",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("m_txtREMINDTERM","住院病案首页>>随诊期限","(IHMC.REMINDTERM<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("诊断符合情况",2,3);	
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("门诊-出院",2,3);
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("无",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>门诊-出院>>无","((select count(ACCORDWITHOUTHOSPITAL) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDWITHOUTHOSPITAL=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("符合",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>门诊-出院>>符合","((select count(ACCORDWITHOUTHOSPITAL) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDWITHOUTHOSPITAL=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("不符",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>门诊-出院>>不符","((select count(ACCORDWITHOUTHOSPITAL) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDWITHOUTHOSPITAL=2)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("待查",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>门诊-出院>>待查","((select count(ACCORDWITHOUTHOSPITAL) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDWITHOUTHOSPITAL=3)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("入院-出院",2,3);
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("无",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>入院-出院>>无","((select count(ACCORDINWITHOUT) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDINWITHOUT=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("符合",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>入院-出院>>符合","((select count(ACCORDINWITHOUT) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDINWITHOUT=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("不符",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>入院-出院>>不符","((select count(ACCORDINWITHOUT) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDINWITHOUT=2)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("待查",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>入院-出院>>待查","((select count(ACCORDINWITHOUT) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDINWITHOUT=3)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("术前-术后",2,3);
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("无",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>术前-术后>>无","((select count(ACCORDBFOPRWITHAF) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDBFOPRWITHAF=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("符合",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>术前-术后>>符合","((select count(ACCORDBFOPRWITHAF) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDBFOPRWITHAF=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("不符",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>术前-术后>>不符","((select count(ACCORDBFOPRWITHAF) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDBFOPRWITHAF=2)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("待查",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>术前-术后>>待查","((select count(ACCORDBFOPRWITHAF) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDBFOPRWITHAF=3)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("临床-病理",2,3);
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("无",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>临床-病理>>无","((select count(ACCORDCLINICWITHPATHOLOGY) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDCLINICWITHPATHOLOGY=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("符合",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>临床-病理>>符合","((select count(ACCORDCLINICWITHPATHOLOGY) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDCLINICWITHPATHOLOGY=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("不符",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>临床-病理>>不符","((select count(ACCORDCLINICWITHPATHOLOGY) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDCLINICWITHPATHOLOGY=2)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("待查",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>临床-病理>>待查","((select count(ACCORDCLINICWITHPATHOLOGY) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDCLINICWITHPATHOLOGY=3)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("死亡-尸检",2,3);
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("无",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>死亡-尸检>>无","((select count(ACCORDDEATHWITHBODYCHECK) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDDEATHWITHBODYCHECK=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("符合",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>死亡-尸检>>符合","((select count(ACCORDDEATHWITHBODYCHECK) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDDEATHWITHBODYCHECK=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("不符",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>死亡-尸检>>不符","((select count(ACCORDDEATHWITHBODYCHECK) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDDEATHWITHBODYCHECK=2)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("待查",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>死亡-尸检>>待查","((select count(ACCORDDEATHWITHBODYCHECK) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDDEATHWITHBODYCHECK=3)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				childNodeChild = new TreeNode("临床-放射",2,3);
				baseNodeChild.Nodes.Add(childNodeChild);

				ccNodeChild = new TreeNode("无",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>临床-放射>>无","((select count(ACCORDCLINICWITHRADIATE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDCLINICWITHRADIATE=0)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("符合",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>临床-放射>>符合","((select count(ACCORDCLINICWITHRADIATE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDCLINICWITHRADIATE=1)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("不符",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>临床-放射>>不符","((select count(ACCORDCLINICWITHRADIATE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDCLINICWITHRADIATE=2)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				ccNodeChild = new TreeNode("待查",2,3);
				ccNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>临床-放射>>待查","((select count(ACCORDCLINICWITHRADIATE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ACCORDCLINICWITHRADIATE=3)<CONDITION>)","BOOL");
				childNodeChild.Nodes.Add(ccNodeChild);

				baseNodeChild = new TreeNode("示教病例",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("是",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>示教病例>>是","((select count(MODELCASE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and MODELCASE=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("否",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>示教病例>>否","((select count(MODELCASE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and MODELCASE=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("手术、治疗、检查、诊断为本院第一例",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("是",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术、治疗、检查、诊断为本院第一例>>是","((select count(FIRSTCASE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and FIRSTCASE=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("否",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>手术、治疗、检查、诊断为本院第一例>>否","((select count(FIRSTCASE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and FIRSTCASE=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("病案质量",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("甲",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>病案质量>>甲","((select count(QUALITY) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and QUALITY=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("乙",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>病案质量>>乙","((select count(QUALITY) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and QUALITY=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("丙",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>病案质量>>丙","((select count(QUALITY) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and QUALITY=3)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("抗菌药物使用",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("是",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>抗菌药物使用>>是","((select count(ANTIBACTERIAL) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ANTIBACTERIAL=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("否",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>抗菌药物使用>>否","((select count(ANTIBACTERIAL) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and ANTIBACTERIAL=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("病原学送检",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("是",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>病原学送检>>是","((select count(PATHOGENY) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and PATHOGENY=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("否",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>病原学送检>>否","((select count(PATHOGENY) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and PATHOGENY=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("病原学送检结果",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("阳性",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>病原学送检结果>>阳性","((select count(PATHOGENYRESULT) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and PATHOGENYRESULT=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("阴性",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>病原学送检结果>>阴性","((select count(PATHOGENYRESULT) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and PATHOGENYRESULT=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("输血反应",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("有",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>输血反应>>有","((select count(BLOODTRANSACTOIN) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODTRANSACTOIN=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("无",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>输血反应>>无","((select count(BLOODTRANSACTOIN) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODTRANSACTOIN=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("输液反应",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("有",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>输液反应>>有","((select count(TRANSFUSIONSACTION) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and TRANSFUSIONSACTION=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("无",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>输液反应>>无","((select count(TRANSFUSIONSACTION) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and TRANSFUSIONSACTION=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("CT检查",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("有",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>CT检查>>有","((select count(CTCHECK) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and CTCHECK=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("无",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>CT检查>>无","((select count(CTCHECK) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and CTCHECK=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("MRI检查",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("有",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>MRI检查>>有","((select count(MRICHECK) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and MRICHECK=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("无",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>MRI检查>>无","((select count(MRICHECK) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and MRICHECK=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("血型",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("不详",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>血型>>不详","((select count(BLOODTYPE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODTYPE=0)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("A",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>血型>>A","((select count(BLOODTYPE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODTYPE=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("B",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>血型>>B","((select count(BLOODTYPE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODTYPE=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("AB",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>血型>>AB","((select count(BLOODTYPE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODTYPE=3)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("O",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>血型>>O","((select count(BLOODTYPE) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODTYPE=4)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("Rh",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("不详",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>Rh>>不详","((select count(BLOODRH) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODRH=0)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("阴",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>Rh>>阴","((select count(BLOODRH) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODRH=1)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("阳",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>Rh>>阳","((select count(BLOODRH) from T_EMR_INHOSPITALMAINREC_GXCON where EMR_SEQ=IHMC.EMR_SEQ and BLOODRH=2)<CONDITION>)","BOOL");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("输血品种",2,3);
				baseNode.Nodes.Add(baseNodeChild);

				childNodeChild = new TreeNode("红细胞",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>红细胞","(IHMC.RBC<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("血小板",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>血小板","(IHMC.PLT<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("血浆",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>血浆","(IHMC.PLASM<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("全血",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>全血","(IHMC.WHOLEBLOOD<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				childNodeChild = new TreeNode("其它",2,3);
				childNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>其它","(IHMC.OTHERBLOOD<CONDITION>)","STRING");
				baseNodeChild.Nodes.Add(childNodeChild);

				baseNodeChild = new TreeNode("科主任ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>科主任","(IHMC.DEPTDIRECTORDT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("科主任",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>科主任","(IHMC.DEPTDIRECTORDT in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("主任医师ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>主任医师","(IHMC.DIRECTORDT<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("主任医师",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>主任医师","(IHMC.DIRECTORDT in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("副主任医师ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>主（副主）任医师","(IHMC.SUBDIRECTORDT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("主（副主）任医师",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>主（副主）任医师","(IHMC.SUBDIRECTORDT in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("主治医师ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>主治医师","(IHMC.DT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("主治医师",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>主治医师","(IHMC.DT in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("入院医师ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>住院医师","(IHMC.INHOSPITALDOC<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("入院医师",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>住院医师","(IHMC.INHOSPITALDOC in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("出院医师ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>出院医师","(IHMC.OUTHOSPITALDOC<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("出院医师",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>出院医师","(IHMC.OUTHOSPITALDOC in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("进修医师ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>进修医师","(IHMC.ATTENDINFORADVANCESSTUDYDT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("进修医师",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>进修医师","(IHMC.ATTENDINFORADVANCESSTUDYDT in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("研究生实习医师",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>研究生实习医师","(IHMC.GRADUATESTUDENTINTERN<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("实习医师",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>实习医师","(IHMC.INTERN<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("住院费用总计",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtTotalAmt","住院病案首页>>住院费用总计","(IHMC.TOTALAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("床位费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtBedAmt","住院病案首页>>床费","(IHMC.BEDAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("护理费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtNurseAmt","住院病案首页>>护理费","(IHMC.NURSEAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("西药费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtWMAmt","住院病案首页>>西药费","(IHMC.WMAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("中成药费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtCMFinishedAmt","住院病案首页>>中成药费","(IHMC.CMFINISHEDAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("中草药费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtCMSemiFinishedAmt","住院病案首页>>中草药费","(IHMC.CMSEMIFINISHEDAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("放射费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtRadiationAmt","住院病案首页>>放射费","(IHMC.RADIATIONAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("化验费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtAssayAmt","住院病案首页>>化验费","(IHMC.ASSAYAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("输氧费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtO2Amt","住院病案首页>>输氧费","(IHMC.O2AMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("输血费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtBloodAmt","住院病案首页>>输血费","(IHMC.BLOODAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("诊疗费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtTreatmentAmt","住院病案首页>>诊疗费","(IHMC.TREATMENTAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("手术费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtOperationAmt","住院病案首页>>手术费","(IHMC.OPERATIONAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("检查费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtCheckAmt","住院病案首页>>检查费","(IHMC.CHECKAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("麻醉费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtAnaethesiaAmt","住院病案首页>>麻醉费","(IHMC.ANAETHESIAAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("接生费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtDeliveryChildAmt","住院病案首页>>接生费","(IHMC.DELIVERYCHILDAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("婴儿费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtBabyAmt","住院病案首页>>婴儿费","(IHMC.BABYAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("陪床费",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtAccompanyAmt","住院病案首页>>陪床费","(IHMC.ACCOMPANYAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("其他费用",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("txtOtherAmt","住院病案首页>>其他费","(IHMC.OTHERAMT<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("编码者ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>编码者","(IHMC.CODINGID<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("编码者",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>编码者","(IHMC.CODINGID in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("整理者ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>整理者","(IHMC.NEATENID<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("整理者",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>整理者","(IHMC.NEATENID in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("入机者ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>入机者","(IHMC.INPUTMACHINEID<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("入机者",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>入机者","(IHMC.INPUTMACHINEID in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("统计者ID",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>统计者","(IHMC.STATISTICID<CONDITION>)","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				baseNodeChild = new TreeNode("统计者",2,3);
				baseNodeChild.Tag = m_objGetDateSearchesType("","住院病案首页>>统计者","(IHMC.STATISTICID in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
				baseNode.Nodes.Add(baseNodeChild);

				m_mthSetCanSearchNodeColor(baseNode);
                //m_mthFoundAndSetTemplate2Node(baseNode,"frmInHospitalMainRecord_GX");
                //m_mthSetToolTips(baseNode);
				m_trvMain.Nodes.Add(baseNode);
				#endregion

			}
			#endregion

			#region 24小时内入出院记录
			baseNode = new TreeNode("24小时内入出院记录",2,2);
			objKeyAndFormName  = new clsKeyAndFormName("S12","frmEMR_OutHospitalIn24Hours","");
			baseNode.Tag = objKeyAndFormName;

			baseNodeChild = new TreeNode("主诉",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtMainDes","主诉","(OH24.MAINDESCRIPTION<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("入院情况",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtInInstance","入院情况","(OH24.INHOSPITALINSTANCE<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("入院诊断",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","入院诊断","(OH24.INHOSPITALDIAGNOSE1<CONDITION> or OH24.INHOSPITALDIAGNOSE2<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("诊疗经过",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtDiagnosisProcess","诊疗经过","(OH24.DIAGNOSECORUSE<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("出院情况",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtOutInstance","出院情况","(OH24.OUTHOSPITALINSTANCE<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("出院诊断",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","出院诊断","(OH24.OUTHOSPITALDIAGNOSE1<CONDITION> or OH24.OUTHOSPITALDIAGNOSE2<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("出院医嘱",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","出院医嘱","(OH24.OUTHOSPITALADVICE1<CONDITION> or OH24.OUTHOSPITALADVICE2<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("签名医师",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","签名医师","(OH24.DOCTORSIGN in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("签名医师ID",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","签名医师ID","(OH24.DOCTORSIGN<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("记录时间",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","记录时间","(IPH.RECORDDATE<CONDITION>)","DATE");
			baseNode.Nodes.Add(baseNodeChild);

			m_mthSetCanSearchNodeColor(baseNode);
            //m_mthFoundAndSetTemplate2Node(baseNode,"frmEMR_OutHospitalIn24Hours");
            //m_mthSetToolTips(baseNode);
			m_trvMain.Nodes.Add(baseNode);
			#endregion

			#region 入院24小时内死亡记录
			baseNode = new TreeNode("入院24小时内死亡记录",2,2);
			objKeyAndFormName  = new clsKeyAndFormName("S13","frmDeathRecordIn24Hours","");
			baseNode.Tag = objKeyAndFormName;

			baseNodeChild = new TreeNode("主诉",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtMainDescription","主诉","(DH24.MAINDESCRIPTION<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("入院情况",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtInHospitalInstance","入院情况","(DH24.INHOSPITALINSTANCE<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("入院诊断",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtInHospitalDiagnose","入院诊断","(DH24.INHOSPITALDIAGNOSE1<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("抢救经过",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtSalvageInstance","诊疗经过","(DH24.SALVAGEINSTANCE<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("死亡原因",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtDeathCausation","诊疗经过","(DH24.DEATHCAUSATION1<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("死亡诊断",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("m_txtDeathDiagonse","诊疗经过","(DH24.DEATHDIAGNOSE1<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("签名医师",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","签名医师","(DH24.DOCTORSIGN in (select Empno_Chr from t_bse_employee where Lastname_Vchr<CONDITION>))","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("签名医师ID",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","签名医师ID","(DH24.DOCTORSIGN<CONDITION>)","STRING");
			baseNode.Nodes.Add(baseNodeChild);

			baseNodeChild = new TreeNode("记录时间",2,3);
			baseNodeChild.Tag = m_objGetDateSearchesType("","记录时间","(DH24.RECORDDATE<CONDITION>)","DATE");
			baseNode.Nodes.Add(baseNodeChild);

			m_mthSetCanSearchNodeColor(baseNode);
            //m_mthFoundAndSetTemplate2Node(baseNode,"frmDeathRecordIn24Hours");
            //m_mthSetToolTips(baseNode);
			m_trvMain.Nodes.Add(baseNode);
			#endregion

			m_mthInitTreeNodes();

			m_mthInitCustomForm();

            #region 医嘱查询
            if (StaticObject::clsEMR_StaticObject.s_StrCurrentHospitalNO == "450101001")//南宁
            {
                //对军惠进行查询，与上述方法不同
                //全部为bool型查询，如果为真，则不将SQL语句拼湊进查询语句
                baseNode = new TreeNode("医嘱查询", 2, 2);
                objKeyAndFormName = new clsKeyAndFormName("S14", "frmDoctorOrder", "");
                baseNode.Tag = objKeyAndFormName;

                baseNodeChild = new TreeNode("医嘱类型", 2, 3);
                baseNode.Nodes.Add(baseNodeChild);

                childNodeChild = new TreeNode("长期", 2, 3);
                childNodeChild.Tag = m_objGetDateSearchesType("", "医嘱查询>>医嘱类型>>长期", "DocOrder.repeat_indicator = 1", "BOOL");
                baseNodeChild.Nodes.Add(childNodeChild);

                childNodeChild = new TreeNode("临时", 2, 3);
                childNodeChild.Tag = m_objGetDateSearchesType("", "医嘱查询>>医嘱类型>>临时", "DocOrder.repeat_indicator = 0", "BOOL");
                baseNodeChild.Nodes.Add(childNodeChild);

                baseNodeChild = new TreeNode("医嘱状态", 2, 3);
                baseNode.Nodes.Add(baseNodeChild);

                childNodeChild = new TreeNode("新开", 2, 3);
                childNodeChild.Tag = m_objGetDateSearchesType("", "医嘱查询>>医嘱状态>>新开", m_objOrderStatus == null ? "" : ("DocOrder.order_status = " + m_objOrderStatus.m_strNEW_STATUS), "BOOL");
                baseNodeChild.Nodes.Add(childNodeChild);

                childNodeChild = new TreeNode("提交", 2, 3);
                childNodeChild.Tag = m_objGetDateSearchesType("", "医嘱查询>>医嘱状态>>提交", m_objOrderStatus == null ? "" : ("DocOrder.order_status = " + m_objOrderStatus.m_strPOST_STATUS), "BOOL");
                baseNodeChild.Nodes.Add(childNodeChild);

                childNodeChild = new TreeNode("转抄", 2, 3);
                childNodeChild.Tag = m_objGetDateSearchesType("", "医嘱查询>>医嘱状态>>转抄", m_objOrderStatus == null ? "" : ("(orders.order_status = " + m_objOrderStatus.m_strPOST_STATUS + " OR orders.order_status IS NULL)"), "BOOL");
                baseNodeChild.Nodes.Add(childNodeChild);

                childNodeChild = new TreeNode("执行", 2, 3);
                childNodeChild.Tag = m_objGetDateSearchesType("", "医嘱查询>>医嘱状态>>执行", m_objOrderStatus == null ? "" : ("(orders.order_status = " + m_objOrderStatus.m_strEXEC_STATUS + " OR orders.order_status IS NULL)"), "BOOL");
                baseNodeChild.Nodes.Add(childNodeChild);

                childNodeChild = new TreeNode("停止中", 2, 3);
                childNodeChild.Tag = m_objGetDateSearchesType("", "医嘱查询>>医嘱状态>>停止中", "", "BOOL");
                baseNodeChild.Nodes.Add(childNodeChild);

                childNodeChild = new TreeNode("已停止", 2, 3);
                childNodeChild.Tag = m_objGetDateSearchesType("", "医嘱查询>>医嘱状态>>已停止", m_objOrderStatus == null ? "" : ("(orders.order_status = " + m_objOrderStatus.m_strSTOP_STATUS + " OR orders.order_status IS NULL)"), "BOOL");
                baseNodeChild.Nodes.Add(childNodeChild);

                childNodeChild = new TreeNode("医生作废", 2, 3);
                childNodeChild.Tag = m_objGetDateSearchesType("", "医嘱查询>>医嘱状态>>医生作废", m_objOrderStatus == null ? "" : ("DocOrder.order_status = " + m_objOrderStatus.m_strCANCEL_STATUS), "BOOL");
                baseNodeChild.Nodes.Add(childNodeChild);

                childNodeChild = new TreeNode("护士作废", 2, 3);
                childNodeChild.Tag = m_objGetDateSearchesType("", "医嘱查询>>医嘱状态>>护士作废", m_objOrderStatus == null ? "" : ("(orders.order_status = " + m_objOrderStatus.m_strCANCEL_STATUS + " OR orders.order_status IS NULL)"), "BOOL");
                baseNodeChild.Nodes.Add(childNodeChild);

                m_mthSetCanSearchNodeColor(baseNode);
                m_trvMain.Nodes.Add(baseNode);
            }
            #endregion
            //ToolTipos


           
			m_trvMain.Nodes[0].Expand();

			m_trvMain.SelectedNode = m_trvMain.Nodes[0].FirstNode;
          

		}

        public string m_StrFindOrderSQL
        {
            get 
            {
                if (m_arlFindOrderSQL.Count == 0)
                    return "";
                else
                {
                    string strTemp = "";
                    for (int i = 0; i < m_arlFindOrderSQL.Count; i++)
                    {
                        clsDataSearchesType SearchesType = m_arlFindOrderSQL[i] as clsDataSearchesType;
                        if (SearchesType != null && !string.IsNullOrEmpty(SearchesType.m_strFieldName))
                        {
                            strTemp += " AND " + SearchesType.m_strFieldName;
                        }
                    }
                    return strTemp;
                }
            }
        }
        //private void m_mthSetNodeTip(TreeNode p_trvNode)
        //{
        //    try
        //    {
        //        m_mthSetToolTips(p_trvNode);
        //        if (p_trvNode.Nodes.Count > 0)
        //        {
        //            for (int i1 = 0; i1 < p_trvNode.Nodes.Count; i1++)
        //            {
        //                //设置每1个节点的Tip
        //                m_mthSetToolTips(p_trvNode.Nodes[i1]);
        //                //如果还有子节点继续循环
        //                if (p_trvNode.Nodes[i1].Nodes.Count > 0)
        //                {
        //                    m_mthSetNodeTip(p_trvNode.Nodes[i1]);
        //                }

        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        clsPublicFunction.ShowInformationMessageBox(e.Source + e.Message + e.StackTrace + e.TargetSite);
        //    }

        //}
		private void m_mthSetCanSearchNodeColor(TreeNode p_trnParent)
		{
			foreach(TreeNode node in p_trnParent.Nodes)
				node.ForeColor = Color.Blue;
		}
		/// <summary>
		/// 初始化专科住院病历
		/// </summary>
		/// <param name="p_objFormInfo"></param>
		private void m_mthInitTreeNodes()
		{
			if(m_objTypeArr == null)
                m_objTypeArr = StaticObject.clsEMR_StaticObject.s_ObjInpatMedRec_DataShare.m_objTypeArr;
//			m_objRecordSearchDomain.m_lngIMR_NewGetFormInfo(out m_objTypeArr);
			if(m_objTypeArr == null)
				return;
			for(int i=0; i<m_objTypeArr.Length; i++)
			{
                clsInpatMedRec_Type_Item[] objItemArr = StaticObject.clsEMR_StaticObject.s_ObjInpatMedRec_DataShare.m_objGetInpatMedRec_Type_Item(m_objTypeArr[i].m_strTypeID);
//				m_objRecordSearchDomain.m_mthIMR_NewGetItemInfo(m_objTypeArr[i].m_strTypeID,out objItemArr);
				if(objItemArr == null)
					continue;
				TreeNode trnChild = new TreeNode(m_objTypeArr[i].m_strTypeName);
				trnChild.Tag = new clsKeyAndFormName("S4",m_objTypeArr[i].m_strTypeID,"");
				for(int j2=0;j2 <objItemArr.Length;j2++)
				{
					clsDataSearchesType objSearchesType = new clsDataSearchesType();
					objSearchesType.m_strFieldName = @"IMR.InPatientID in (select InPatientID from InpatMedRec_Item 
where TypeID = '"+objItemArr[j2].m_strTypeID+"'and ItemID = '"+objItemArr[j2].m_strItemID + "'";
					if(objItemArr[j2].m_strItemType == "ctlTimePicker")
					{
                        if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "440104001")
							objSearchesType.m_strFieldName += " and convert(datetime,itemcontent) <CONDITION>)";
						else
							objSearchesType.m_strFieldName += " and to_date(to_char(itemcontent,'yyyy-mm-dd hh24:mi:ss'),'yyyy-mm-dd hh24:mi:ss') <CONDITION>)";
						objSearchesType.m_strDataType = "DATE";
					}
					else
					{
						objSearchesType.m_strFieldName += " and itemcontent <CONDITION>)";
						objSearchesType.m_strDataType = "STRING";
					}
					objSearchesType.m_strItemID = objItemArr[j2].m_strItemID;
					objSearchesType.m_strItemDesc = m_objTypeArr[i].m_strTypeName+">>"+objItemArr[j2].m_strItemName;
					objSearchesType.m_strItemType = objItemArr[j2].m_strItemType;
					m_mthAddTreeNode(objSearchesType,trnChild,objItemArr[j2].m_strItemName);
				}
                //m_mthFoundAndSetTemplate2Node(trnChild,m_objTypeArr[i].m_strTypeID);
                //m_mthSetToolTips(trnChild);
				m_trvMain.Nodes.Add(trnChild);
			}
		}

		/// <summary>
		/// 递归添加树结点（专科病历）
		/// </summary>
		/// <param name="p_objFieldInfo">绑定叶结点Tag的Object</param>
		/// <param name="p_tnParent"></param>
		/// <param name="p_strFieldName"></param>
		private void m_mthAddTreeNode(clsDataSearchesType p_objFieldInfo,TreeNode p_tnParent,string p_strFieldName)
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
						tnSubNode = new TreeNode(strFirstItem,2,3);
						p_tnParent.Nodes.Add(tnSubNode);
						m_mthAddTreeNode(p_objFieldInfo,tnSubNode,p_strFieldName);
					}
					return;
				}
				else
				{
					//子结点为空
					tnSubNode = new TreeNode(strFirstItem,2,3);
					p_tnParent.Nodes.Add(tnSubNode);
					m_mthAddTreeNode(p_objFieldInfo,tnSubNode,p_strFieldName);
				}
				return;
			}
			else
			{
				tnSubNode = new TreeNode(p_strFieldName,2,3);
				tnSubNode.Tag = p_objFieldInfo;
				tnSubNode.ForeColor = Color.Blue;
			}
			p_tnParent.Nodes.Add(tnSubNode);
		}
		/// <summary>
		/// 设置最小元素结点
		/// </summary>
		/// <param name="p_trnPatent"></param>
		/// <param name="p_strFormID"></param>
		private void m_mthFoundAndSetTemplate2Node(TreeNode p_trnPatent,string p_strFormID)
		{
			foreach(TreeNode node in p_trnPatent.Nodes)
			{
				if(node.Tag is clsDataSearchesType)
				{
					clsDataSearchesType objSearchesType = node.Tag as clsDataSearchesType;
					if(objSearchesType.m_strItemID == "" || !(objSearchesType.m_strItemType == "ctlRichTextBox" || objSearchesType.m_strItemType == "RichTextBox"))
						continue;
					clsTemplateInfo[] objTemplateInfoArr = null;
					m_objRecordSearchDomain.m_lngGetTemplateName(p_strFormID,objSearchesType.m_strItemID,out objTemplateInfoArr);
					if(objTemplateInfoArr != null && objTemplateInfoArr.Length > 0)
					{
						for(int j2=0;j2<objTemplateInfoArr.Length;j2++)
						{
							TreeNode templateNode = new TreeNode(objTemplateInfoArr[j2].m_strTEMPLATE_NAME);
							templateNode.Tag = new clsKeyAndFormName("S41",p_strFormID,objTemplateInfoArr[j2].m_strTEMPLATE_ID);
							templateNode.Nodes.Add("temp");
							node.Nodes.Add(templateNode);
						}
					}
				}
				else
					m_mthFoundAndSetTemplate2Node(node,p_strFormID);
			}
		}
		/// <summary>
		/// 提交自定义表单
		/// </summary>
		private void m_mthInitCustomForm()
		{
			TreeNode CustomNode = new TreeNode("自定义表单");
			CustomForm.clsCustomPublicFuntion objFunc = new iCare.CustomForm.clsCustomPublicFuntion();
			objFunc.m_BlnIsSearchesType = true;
			objFunc.m_mthLoadType(CustomNode);
			objFunc.m_mthSetFormToNode(CustomNode);
			objFunc.m_mthClearEmptyTypeNode(CustomNode);
            //m_mthSetToolTips(CustomNode);
			m_trvMain.Nodes.Add(CustomNode);
		}
		#endregion

		/// <summary>
		/// 条件专科病历菜单并关联事件
		/// </summary>
		private void m_mthInitMenu()
		{
			if(m_objTypeArr != null)
			{
				for(int i=0;i<m_objTypeArr.Length;i++)
				{
					MenuItem item = new MenuItem(m_objTypeArr[i].m_strTypeName);
//					m_ctmExplorer.MenuItems.Add(i+2,item);
					m_mtmInpatMedRec.MenuItems.Add(i,item);
				}
			}
			foreach(MenuItem mniSub in m_ctmExplorer.MenuItems)
				m_mthAssociateItemEvent(mniSub);
		}

        #region 初始化菜单
        /// <summary>
        /// 初始化菜单
        /// </summary>
        private void m_mthInitEMRMenu()
        {
            clsEmrModuleMemuItem objMenu = new clsEmrModuleMemuItem();
            objMenu.m_mthGetEmrModuleMemu(this.m_cmsEMRMenu);
            objMenu = null;
        }
        #endregion

		/// <summary>
		/// 设置查询类型
		/// </summary>
		/// <param name="p_strFormName"></param>
		/// <param name="p_strControlName"></param>
		/// <param name="p_strControlDesc"></param>
		/// <param name="p_strFieldName"></param>
		/// <param name="p_strDataType"></param>
		/// <returns></returns>
		private clsDataSearchesType m_objGetDateSearchesType(string p_strControlName,string p_strControlDesc,string p_strFieldName,string p_strDataType)
		{
			clsDataSearchesType objSearchesType = new clsDataSearchesType();
			objSearchesType.m_strDataType = p_strDataType;
			objSearchesType.m_strFieldName = p_strFieldName;

			objSearchesType.m_strItemID = p_strControlName;
			objSearchesType.m_strItemDesc = p_strControlDesc;
			if(p_strControlName != "")
				objSearchesType.m_strItemType = "ctlRichTextBox";
			return objSearchesType;
		}

		/// <summary>
		/// 添加条件类型项目
		/// </summary>
		private void m_mthAddComboItem()
		{
			m_cboDateConditionType.AddRangeItems(m_objMakeInfo.m_objGetExpItemArr("DATE"));
			m_cboDateConditionType.SelectedIndex = 0;

			m_cboLongTextConditionType.AddRangeItems(m_objMakeInfo.m_objGetExpItemArr("STRING"));
			m_cboLongTextConditionType.SelectedIndex = 0;

			m_cboNumberConditionType.AddRangeItems(m_objMakeInfo.m_objGetExpItemArr("INT"));
			m_cboNumberConditionType.SelectedIndex = 0;
		}

		
		/// <summary>
		/// 显示查询条件输入
		/// </summary>
		/// <param name="p_strType">条件类型</param>
		private void m_mthSetInputVisible(string p_strType)
		{
			m_txtLongTextContent.Text = "";
			m_txtNumberFrom.Text = "";
			m_txtNumberTo.Text = "";
			m_pnlLongText.Visible = (p_strType == "STRING");
			m_pnlTrueFalse.Visible = (p_strType == "BOOL");
			m_pnlDate.Visible = (p_strType == "DATE");
			m_pnlNumber.Visible = (p_strType == "INT");
			m_cmdAddCondition.Enabled = (m_pnlLongText.Visible || m_pnlDate.Visible || m_pnlTrueFalse.Visible || m_pnlNumber.Visible);
		}
		/// <summary>
		/// 返回结点Tag是clsKeyAndFormName的类
		/// </summary>
		/// <param name="p_trnParent"></param>
		/// <returns></returns>
		private clsKeyAndFormName m_objGetParnetTag(TreeNode p_trnParent)
		{
			if(p_trnParent != null)
			{
				if(p_trnParent.Tag is clsKeyAndFormName)
					return (clsKeyAndFormName)p_trnParent.Tag;
				else
					return m_objGetParnetTag(p_trnParent.Parent);
			}
			else 
				return null;
		}
		/// <summary>
		/// 获得查询条件
		/// </summary>
		private clsDateSearchesCondition m_objSetInputCondition()
		{
			clsDataSearchesType objSearchesType = m_trvMain.SelectedNode.Tag as clsDataSearchesType;
			clsKeyAndFormName objKeyAndFormName = m_objGetParnetTag(m_trvMain.SelectedNode.Parent);
			if(objSearchesType == null || objKeyAndFormName == null)
				return null;
			
			clsDateSearchesCondition objCondition = new clsDateSearchesCondition();

			if(m_pnlLongText.Visible)
			{
				if(m_txtLongTextContent.Text.TrimEnd() == "")
				{
					MDIParent.ShowInformationMessageBox("条件不能都为空！请填写合适的条件。");
					m_txtLongTextContent.Focus();
					return null;
				}
				clsExpressionInfo obj = m_cboLongTextConditionType.SelectedItem as clsExpressionInfo;

				objCondition.m_strName = objSearchesType.m_strItemDesc;
				objCondition.m_objSelectedItem = (clsExpressionInfo)m_cboLongTextConditionType.SelectedItem;
				objCondition.m_strFirstValue = m_txtLongTextContent.Text.TrimEnd();
				objCondition.m_strSQLKey = objKeyAndFormName.m_strSQLKey;
				objCondition.m_strSearchesSQL = " and " + objSearchesType.m_strFieldName.Replace("<CONDITION>",obj.m_strExpressionArr.Replace("<CONTENT>",m_txtLongTextContent.Text.TrimEnd()));

			}
			else if(m_pnlDate.Visible)
			{
				clsExpressionInfo obj = m_cboDateConditionType.SelectedItem as clsExpressionInfo;

				objCondition.m_strName = objSearchesType.m_strItemDesc;
				objCondition.m_objSelectedItem = (clsExpressionInfo)m_cboDateConditionType.SelectedItem;
				objCondition.m_strFirstValue = "<FIRST>" +m_dtpFirst.Value.ToString("yyyy年MM月dd日");
				objCondition.m_strSecondValue = (m_dtpSecond.Visible?"<SECOND>"+m_dtpSecond.Value.ToString("yyyy年MM月dd日"):"");
				objCondition.m_strSQLKey = objKeyAndFormName.m_strSQLKey;
                if (m_dtpSecond.Visible)
                {
                    objCondition.m_strSearchesSQL = " and " + objSearchesType.m_strFieldName.Replace("<CONDITION>", obj.m_strExpressionArr.Replace("<FIRSTDATE>", clsDatabaseSQLConvert.s_strGetSQLDateTimeFormat(m_dtpFirst.Value.Date)).Replace("<ENDDATE>", clsDatabaseSQLConvert.s_strGetSQLDateTimeFormat(m_dtpSecond.Value.Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss"))));
                }
                else
                {
                    objCondition.m_strSearchesSQL = " and " + objSearchesType.m_strFieldName.Replace("<CONDITION>", obj.m_strExpressionArr.Replace("<FIRSTDATE>", clsDatabaseSQLConvert.s_strGetSQLDateTimeFormat(m_dtpFirst.Value.Date)).Replace("<ENDDATE>", clsDatabaseSQLConvert.s_strGetSQLDateTimeFormat(m_dtpFirst.Value.Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss"))));
                }
				
				
			}
			else if(m_pnlTrueFalse.Visible)
			{
				if(m_rdbTrueFalseTrue.Checked == false && m_rdbTrueFalseFalse.Checked == false)
				{
					MDIParent.ShowInformationMessageBox("条件不能都为空！请选择一个。");
					return null;
				}

				objCondition.m_strName = objSearchesType.m_strItemDesc;
				objCondition.m_blnBoolValue = m_rdbTrueFalseTrue.Checked;
                objCondition.m_strSQLKey = objKeyAndFormName.m_strSQLKey;

                if (objKeyAndFormName.m_strSQLKey == "S14")
                {
                    objCondition.m_strSearchesSQL = "";
                    m_mthSetFingOrderSQL(objSearchesType, m_rdbTrueFalseTrue.Checked);
                }
                else
                {
                    objCondition.m_strSearchesSQL = " and " + objSearchesType.m_strFieldName.Replace("<CONDITION>", (m_rdbTrueFalseTrue.Checked ? " > 0 " : " <= 0 "));
                }

			}
			else if(m_pnlNumber.Visible)
			{
				if((m_txtNumberFrom.Text.Trim() == "" && m_txtNumberTo.Visible && m_txtNumberTo.Text.Trim() == "") || (m_txtNumberFrom.Text.Trim() == "" && !m_txtNumberTo.Visible))
				{
					MDIParent.ShowInformationMessageBox("条件不能都为空！请填写合适的条件。");
					m_txtNumberFrom.Focus();
					return null;
				}
				clsExpressionInfo obj = m_cboNumberConditionType.SelectedItem as clsExpressionInfo;

				objCondition.m_strName = objSearchesType.m_strItemDesc;
				objCondition.m_objSelectedItem = (clsExpressionInfo)m_cboNumberConditionType.SelectedItem;
				objCondition.m_strFirstValue = "<FIRST>" +m_txtNumberFrom.Text.Trim();
				objCondition.m_strSecondValue = (m_txtNumberTo.Visible?"<SECOND>"+m_txtNumberTo.Text.Trim():"");
				objCondition.m_strSQLKey = objKeyAndFormName.m_strSQLKey;
				objCondition.m_strSearchesSQL = " and " + objSearchesType.m_strFieldName.Replace("<CONDITION>",obj.m_strExpressionArr.Replace("<FIRSTNUMBER>",m_txtNumberFrom.Text.Trim()).Replace("<ENDNUMBER>",m_txtNumberTo.Text.Trim()));
			}
			return objCondition;
		}

        /// <summary>
        /// 设置医嘱查询SQL
        /// </summary>
        /// <param name="p_objSearchesType"></param>
        /// <param name="p_blnIsTrue">如果是布尔型，显示当前选中状况</param>
        private void m_mthSetFingOrderSQL(clsDataSearchesType p_objSearchesType, bool p_blnIsTrue)
        {
            if(p_objSearchesType == null)
                return;

            for (int i = 0; i < m_arlFindOrderSQL.Count; i++)
            {
                if (((clsDataSearchesType)m_arlFindOrderSQL[i]).m_strFieldName == p_objSearchesType.m_strFieldName)
                {
                    return;
                }
            }

            clsDataSearchesType objSearchesTypeClone = new clsDataSearchesType();
            if (m_pnlTrueFalse.Visible && !p_blnIsTrue)
            {
                objSearchesTypeClone.m_strDataType = p_objSearchesType.m_strDataType;
                objSearchesTypeClone.m_strFieldName =
                    p_objSearchesType.m_strFieldName.Replace("=", "<>").Replace("OR orders.order_status IS NULL", "and orders.order_status IS not NULL");
                objSearchesTypeClone.m_strItemDesc = p_objSearchesType.m_strItemDesc;
                objSearchesTypeClone.m_strItemID = p_objSearchesType.m_strItemID;
                objSearchesTypeClone.m_strItemType = p_objSearchesType.m_strItemType;
            }
            else
                objSearchesTypeClone = p_objSearchesType;
            m_arlFindOrderSQL.Add(objSearchesTypeClone);
        }

		/// <summary>
		/// 查找树结点
		/// </summary>
		/// <param name="p_strKey"></param>
		/// <param name="p_strName"></param>
		private void m_mthFoundNode(string p_strName)
		{
			foreach(TreeNode node in m_trvMain.Nodes)
			{
				if(p_strName.StartsWith(node.Text))
				{
					m_mthFoundSubNode(node, p_strName);
					break;
				}
			}
		}
		private bool m_blnEqualString(string p_strNodeText,string p_strPathText)
		{
			int intIndex = p_strPathText.IndexOf(">>");
			if(intIndex >= 0)
				if(p_strPathText.Substring(0,intIndex) == p_strNodeText)
					return true;

			return false;
		}
		/// <summary>
		/// 查找树结点(循环调用)
		/// </summary>
		/// <param name="p_strKey"></param>
		/// <param name="p_strName"></param>
		private void m_mthFoundSubNode(TreeNode p_trnChild,string p_strName)
		{
			string strName = p_strName.Substring(p_trnChild.Text.Length+2);
			if(strName.LastIndexOf(">>") >= 0)
			{
				foreach(TreeNode trnChild in p_trnChild.Nodes)
				{
					if(m_blnEqualString(trnChild.Text,strName))
					{
						m_mthFoundSubNode(trnChild,strName);
						return;
					}
				}
			}
			else
			{
				foreach(TreeNode node in p_trnChild.Nodes)
				{
					if(node.Text == strName)
					{
						m_trvMain.SelectedNode = node;
						return;
					}
				}
			}
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

			try
			{
				this.Cursor=Cursors.WaitCursor;
				p_frmRecord.MdiParent = this.MdiParent;
				p_frmRecord.Show(); 
				frmHRPBaseForm frmRecord = p_frmRecord as frmHRPBaseForm;
				if(frmRecord != null)
				{
                    objSelectPatient.m_IntCharacter = 1;
                    if (clsEMRLogin.m_ObjCurDeptOfEmpArr != null)
                    {
                        for (int j1 = 0; j1 < clsEMRLogin.m_ObjCurDeptOfEmpArr.Length; j1++)
                        {
                            if (clsEMRLogin.m_ObjCurDeptOfEmpArr[j1].strDeptID == MDIParent.m_objCurrentDepartment.m_strDEPTID_CHR)
                            {
                                objSelectPatient.m_IntCharacter = 0;
                                break;
                            }
                        }
                    }
					frmRecord.m_mthSetPatient(objSelectPatient);
				}
				this.Cursor=Cursors.Default;
			}
			catch(Exception ex)
			{string str = ex.Message;}
		}
		/// <summary>
		/// 关联菜单事件
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

		
		/// <summary>
		/// 获取表单ID
		/// </summary>
		/// <param name="p_strFormName"></param>
		/// <returns></returns>
		private string m_strGetTypeId(string p_strFormName)
		{
			if(m_objTypeArr != null)
			{
				for(int i=0;i<m_objTypeArr.Length;i++)
				{
					if(m_objTypeArr[i].m_strTypeName == p_strFormName)
						return m_objTypeArr[i].m_strTypeID;
				}
			}
			return null;
		}
		/// <summary>
		/// Load出自定义表单字段
		/// </summary>
		/// <param name="p_trnSender"></param>
		private void m_mthLoadCustomFormFields(TreeNode p_trnSender)
		{
			if(p_trnSender.FirstNode != null)
			{
				if(p_trnSender.FirstNode.Tag is CustomForm.clsCustomSyncField)
					 return;
			}
			p_trnSender.Nodes.Clear();
			clsCustom_SubmitValue objValue = p_trnSender.Tag as clsCustom_SubmitValue;
			for(int j2 = 0;j2<objValue.m_objPagesArr.Length;j2++)
			{
				CustomForm.clsCustomSyncField[] objFieldArr = new CustomForm.clsConfigXmlTool().m_objGetSyncFieldFromSubmitXml(objValue.m_objPagesArr[j2].m_strConfiguration);
				if(objFieldArr != null)
				{
					for(int i=0;i<objFieldArr.Length;i++)
					{
						TreeNode trnFieldNode = new TreeNode(objFieldArr[i].m_strFieldName);
						trnFieldNode.Tag = objFieldArr[i];
						trnFieldNode.ForeColor = Color.Blue;
						p_trnSender.Nodes.Add(trnFieldNode);
					}
				}
			}
		}
		/// <summary>
		/// Load出最小元素结点
		/// </summary>
		/// <param name="e"></param>
		private void m_mthLoadMineElement(TreeViewCancelEventArgs e)
		{
			if(e.Node.FirstNode != null)
			{
				if(e.Node.FirstNode.Tag is clsDataSearchesType)
					return;
			}
			clsKeyAndFormName objKeyAndFormName = e.Node.Tag as clsKeyAndFormName;
			if(objKeyAndFormName == null)
				return;
			if(objKeyAndFormName.m_strTemplateID == "")
				return;
			TreeNode trnNode = e.Node;
			clsDataSearchesType objTmp = trnNode.Parent.Tag as clsDataSearchesType;
			string strDesc = "";
			if(objTmp != null)
				strDesc = objTmp.m_strItemDesc;//当前结点路径
			m_trvMain.BeginUpdate();
			trnNode.Nodes.Clear();
			clsTemplateControlValue[] objTemplateControlArr = null;
			m_objRecordSearchDomain.m_lngGetTemplateControls(objKeyAndFormName.m_strTemplateID,out objTemplateControlArr);
			if(objTemplateControlArr == null || objTemplateControlArr.Length <= 0)
			{
				m_trvMain.EndUpdate();
				return;
			}
			for(int i=0;i<objTemplateControlArr.Length;i++)
			{
				TreeNode node = new TreeNode(objTemplateControlArr[i].m_strCONTROL_DESC,2,3);
				clsDataSearchesType objType = new clsDataSearchesType();
				objType.m_strItemID = objTemplateControlArr[i].m_strCONTROL_ID;
				objType.m_strItemDesc = strDesc+">>"+trnNode.Text+">>"+objTemplateControlArr[i].m_strCONTROL_DESC;
                objType.m_strFieldName = @" mv.registerid_chr in (select elm.registerid_chr
                       from min_elementcol_valuesub els
                      inner join min_elementcol_valuemain elm on els.valueid_int =
                                                                 elm.valueid_int
                      where elm.templateid_chr = '" + objKeyAndFormName.m_strTemplateID + "' and els.controlid_vchr = '" + objTemplateControlArr[i].m_strCONTROL_ID + "'  and ";
				if(objTemplateControlArr[i].m_strCONTROL_ID.StartsWith("ctlDateTimePicker"))
				{
                    objType.m_strFieldName += clsDatabaseSQLConvert.s_strGetConvertToDateSQL("els.controlvalue_vchr") + " <CONDITION>)";
					objType.m_strDataType = "DATE";
				}
				else
				{
                    objType.m_strFieldName += " els.controlvalue_vchr <CONDITION>)";
					objType.m_strDataType = "STRING";
				}
				node.Tag = objType;
				node.ForeColor = Color.Blue;
				trnNode.Nodes.Add(node);
			}
			
			m_trvMain.EndUpdate();
		}
		
		#region Event

		private void m_cboDateConditionType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_cboDateConditionType.SelectedIndex < 0)
				return;
			bool blnVisible = ( m_cboDateConditionType.SelectedIndex == 1);
			m_lblDateFrom.Visible = blnVisible;
			m_lblDateTo.Visible = blnVisible;
			m_dtpSecond.Visible = blnVisible;
			if(blnVisible)//控制初始条件为当前月
			{
				m_dtpFirst.Text = DateTime.Now.ToString("yyyy-MM-01 00:00:00");
				m_dtpSecond.Text = m_dtpFirst.Value.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd 00:00:00");
			}
		}

		private void m_cboNumberConditionType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_cboNumberConditionType.SelectedIndex < 0)
				return;
			bool blnVisible = (m_cboNumberConditionType.SelectedIndex == 1);
			m_lblNumberTo.Visible = blnVisible;
			m_txtNumberTo.Visible = blnVisible;
		}

		private void m_cmdAddCondition_Click(object sender, System.EventArgs e)
		{
			if(m_trvMain.SelectedNode == null)
				return;
			clsDataSearchesType objSearchesType = m_trvMain.SelectedNode.Tag as clsDataSearchesType;
			if(objSearchesType == null)
			{
				m_mthAddCustomFormCondotion(m_trvMain.SelectedNode);
				return;
			}
			clsDateSearchesCondition objCondition = m_objSetInputCondition();
			if(objCondition == null)
				return;
			for(int i=0;i<m_lstConditionList.Items.Count;i++)
			{
				//控制不能插入重复条件
                if (objCondition.m_strSearchesSQL != "" && ((clsDateSearchesCondition)m_lstConditionList.Items[i]).m_strSearchesSQL == objCondition.m_strSearchesSQL)
					return;
			}
			m_lstConditionList.Items.Add(objCondition);
		}

		private void m_cmdClearResult_Click(object sender, System.EventArgs e)
		{
			m_lsvPatientList.Items.Clear();
			m_txtPatientInfo.Text = "";
			m_lblPatientCount.Text= "人数：";
			m_lblPatientTimesCount.Text = "人次：";
		}

		private void m_cboLongTextConditionType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_cboLongTextConditionType.SelectedIndex < 0)
				return;
		}

		private void m_cmdSearch_Click(object sender, System.EventArgs e)
		{
			m_lsvPatientList.Items.Clear();
            if (clsEMRLogin.m_StrCurrentHospitalNO == "450101001" && m_lstConditionList.Items.Count == 0)//南宁
            { 
                clsPublicFunction.ShowInformationMessageBox("请指定条件后再查询!");
                ttpMain.Show("请添加要查询的条件到此！", m_lstConditionList,2000);
                return;
            }
            if (m_cboDept.Enabled)
            {
                if (m_cboDept.GetItemsCount() <= 0)
                    return;
                else
                {
                    clsEmrDept_VO objDeptVO = m_cboDept.SelectedItem as clsEmrDept_VO;
                    if (objDeptVO == null)
                        return;

                    int intDeptAttribute = 3;
                    if (objDeptVO.m_strATTRIBUTEID == "0000003")
                    {
                        intDeptAttribute = 3;
                    }
                    else
                    {
                        intDeptAttribute = 2;
                    }

                    m_objMakeInfo = new clsDataSearchesMake(true, objDeptVO.m_strDEPTID_CHR, intDeptAttribute, this);
                    if (objDeptVO.m_strATTRIBUTEID == "0000003")
                    {
                        m_objMakeInfo.m_DeptAttribute = 3;
                    }
                    else
                    {
                        m_objMakeInfo.m_DeptAttribute = 2;
                    }
                }
            }
            else if (m_chkAllDept.Checked)
            {
                m_objMakeInfo = new clsDataSearchesMake(false, "",3, this);
            }
            else
            {
                clsPublicFunction.ShowInformationMessageBox("请指定科室或全部科室后再查询!");
                ttpMain.Show("请选择科室或全部科室！", pnlDept, 2000);
                return;
            }

			m_mthSave();
		}
		private void m_mthSave()
		{
			frmBusynessForm frm = new frmBusynessForm("正在搜索，请稍候...");
			frm.BusynessEvent +=new iCare.frmBusynessForm.BusynessHandler(frm_BusynessEvent);
			frm.ShowDialog();
            Application.DoEvents();
		}
		private void frm_BusynessEvent(object sender,BusynessEventArgs e)
		{
			try
			{
				m_txtPatientInfo.Text = "";
				Hashtable hasKey = new Hashtable();
                ArrayList arrStorHasKey = new ArrayList();
                string strMainSql = @"select distinct <S3>.FirstName,<S1>.inpatientid,<S1>.inpatientdate,<S1>.OutDate,<S1>.deptid,<S1>.areaid,<S1>.EXTENDID_VCHR,
                                            <S1>.EMRINPATIENTID,   <S1>.EMRINPATIENTDATE, <S1>.registerid_chr from ";
				if(m_lstConditionList.Items.Count <= 0)
				{
					//没有条件，查找当前科室下所有病人
//					strMainSql += "InPatientDateInfo <S1> inner join indeptinfo S2 on <S1>.inpatientid  = S2.inpatientid and <S1>.inpatientdate  = S2.inpatientdate inner join PatientBaseInfo S3 on S2.inpatientid = S3.inpatientid where ( "+m_objMakeInfo.m_mthGetAllManageDept("S2")+")";
//                    strMainSql += @"T_BSE_PATIENT S3
//							inner join T_OPR_BIH_REGISTER S1 on S3.PATIENTID_CHR = S1.PATIENTID_CHR
//							left outer join (select * from T_OPR_BIH_LEAVE where status_int = 1) S4 on S4.REGISTERID_CHR = S1.REGISTERID_CHR
//							inner join T_BSE_DEPTDESC S2 on S1.DEPTID_CHR = S2.DEPTID_CHR where ( "+m_objMakeInfo.m_mthGetAllRelationDept("S2")+")";
                    strMainSql += @"t_opr_bih_registerdetail pa
                             inner join T_OPR_BIH_REGISTER re on pa.registerid_chr = re.registerid_chr and re.STATUS_INT <> 0 and re.PSTATUS_INT <> 0 and re.bedid_chr is not null
                            inner join T_BSE_HISEMR_RELATION rehis on rehis.registerid_chr = re.registerid_chr
                             inner join T_OPR_BIH_TRANSFER tr on tr.registerid_chr = re.registerid_chr
                              left outer join T_OPR_BIH_LEAVE le on le.REGISTERID_CHR =
                                          re.REGISTERID_CHR
                                          and le.status_int = 1
                             where (" + m_objMakeInfo.m_mthGetRelationDept("tr") + ")";
//					strMainSql = strMainSql.Replace("<S1>","base").Replace("<S3>","S3");
                    strMainSql = strMainSql.Replace("<S1>.inpatientid", "rehis.hisinpatientid_chr inpatientid").Replace("<S3>.", "pa.LASTNAME_VCHR ").Replace("<S1>.inpatientdate", "rehis.hisinpatientdate inpatientdate")
                        .Replace("<S1>.OutDate", "le.modify_dat OutDate").Replace("<S1>.deptid", "re.deptid_chr DeptID").Replace("<S1>.areaid", "re.areaid_chr AreaID").Replace("<S1>.EMRINPATIENTID", "rehis.emrinpatientid")
                        .Replace("<S1>.EMRINPATIENTDATE", "rehis.emrinpatientdate").Replace("<S1>.EXTENDID_VCHR", "re.EXTENDID_VCHR").Replace("<S1>.registerid_chr", "re.registerid_chr");
				}
				else
				{
					bool blnCanReturn = true;
					//默认添加，否则没有姓名
					hasKey.Add("S1",m_objMakeInfo.m_strGetMainSQL("S1"));
                    arrStorHasKey.Add("S1");
					for(int j=0;j<m_lstConditionList.Items.Count;j++)
					{
						if(m_lstConditionList.Items[j] is clsCustomSearchesCondition)
						{
							m_mthSearchesCustomFormData((clsCustomSearchesCondition)m_lstConditionList.Items[j]);
							continue;
						}
						blnCanReturn = false;
						clsDateSearchesCondition objCondition = m_lstConditionList.Items[j] as clsDateSearchesCondition;
                        if (hasKey.ContainsKey(objCondition.m_strSQLKey) && objCondition.m_strSQLKey != "S14")
						{
							//如果为同一主SQL，则只添加Where条件
							string strTemp = (string)hasKey[objCondition.m_strSQLKey];
							strTemp += objCondition.m_strSearchesSQL;
							hasKey[objCondition.m_strSQLKey] = strTemp;
						}
						else if(objCondition.m_strSQLKey != "S14")
						{
							string strSql = m_objMakeInfo.m_strGetMainSQL(objCondition.m_strSQLKey) + objCondition.m_strSearchesSQL;
							hasKey.Add(objCondition.m_strSQLKey,strSql);
                            arrStorHasKey.Add(objCondition.m_strSQLKey);
						}
					}
					if(blnCanReturn)
					{
						if(m_lsvPatientList.Items.Count > 0)
							m_lsvPatientList.Items[0].Selected = true;
						e.EndMessage = "搜索完成";
                        Application.DoEvents();
						e.Closing = true;
						m_mthAddResultToListView();
						m_mthClear();
						return;
					}
					if(hasKey.Count > 0)//连接全部条件成最终可执行SQL
					{
						string[] strKeysArr = new string[hasKey.Count];
                        //hasKey.Keys.CopyTo(strKeysArr,0);
                        //for(int k=0;k<hasKey.Count;k++)
                        //{
                        //    strMainSql += (k == 0?"(" + hasKey[strKeysArr[k]] + ") " + strKeysArr[k]:" inner join (" + hasKey[strKeysArr[k]] + ") " + strKeysArr[k]);
                        //    if(k > 0)
                        //        strMainSql += " on rtrim("+strKeysArr[k-1] + ".inpatientid) = rtrim("+strKeysArr[k] + ".inpatientid) and "+strKeysArr[k-1] + ".inpatientdate = "+strKeysArr[k] + ".inpatientdate ";
                        //}
                        for (int k = 0; k < arrStorHasKey.Count; k++)
                        {
                            strMainSql += (k == 0 ? "(" + hasKey[arrStorHasKey[k].ToString()] + ") " + arrStorHasKey[k].ToString() : " inner join (" + hasKey[arrStorHasKey[k].ToString()] + ") " + arrStorHasKey[k].ToString());
                            if (k > 0)
                            {
                                if (k == 1)
                                {
                                    strMainSql += " on " + arrStorHasKey[0].ToString() + ".EMRINPATIENTID = " + arrStorHasKey[1].ToString() + ".inpatientid and " + arrStorHasKey[0].ToString() + ".EMRINPATIENTDATE = " + arrStorHasKey[1].ToString() + ".inpatientdate ";
                                }
                                else
                                {
                                    strMainSql += " on " + arrStorHasKey[k - 1].ToString() + ".inpatientid = " + arrStorHasKey[k].ToString() + ".inpatientid and " + arrStorHasKey[k - 1].ToString() + ".inpatientdate = " + arrStorHasKey[k].ToString() + ".inpatientdate ";
                                }
                            }
                        }
                        //strMainSql += " order by <S1>.inpatientid";
                        //strMainSql = strMainSql.Replace("<S1>",strKeysArr[0]).Replace("<S3>",strKeysArr[0]);//.Replace("<INDEPTID>",MDIParent.s_ObjDepartment.m_StrDeptID);
                        strMainSql = strMainSql.Replace("<S1>", arrStorHasKey[0].ToString()).Replace("<S3>", arrStorHasKey[0].ToString());
					}
				}
				DataTable dtValue = new DataTable();
				m_objRecordSearchDomain.m_lngSearchesBySQL(strMainSql,ref dtValue);

                DataTable dtOrder = new DataTable();
                if (m_blnSearchOrders())
                {
                    m_objRecordSearchDomain.m_lngGetOrdersPatient(m_objMakeInfo.m_strGetMainSQL("S14"), out dtOrder);
                    DataTable dtTemp = dtValue.Clone();
                    if (dtValue.Rows.Count > 0 && dtOrder.Rows.Count > 0)
                    {
                        DataTable dtbDistinctOrder = new clsPublicFunction().Distinct(dtOrder, new DataColumn[] { dtOrder.Columns[0], dtOrder.Columns[1] });
                        
                        for (int m = 0; m < dtValue.Rows.Count; m++)
                        {
                            for (int n = 0; n < dtbDistinctOrder.Rows.Count; n++)
                            {
                                if (dtValue.Rows[m]["INPATIENTID"].ToString().Trim() == dtbDistinctOrder.Rows[n]["patient_id"].ToString().Trim()
                                    && dtValue.Rows[m]["EXTENDID_VCHR"].ToString() == dtbDistinctOrder.Rows[n]["patient_id"].ToString().Trim() + "_" + dtbDistinctOrder.Rows[n]["visit_id"].ToString().Trim())
                                {
                                    dtTemp.Rows.Add(dtValue.Rows[m]);
                                    break;
                                }
                            }
                        }
                    }
                    dtValue = dtTemp;
                }
                e.Messages = "正在添加到列表...";
                Application.DoEvents();
				//添加查找结果列表
				if(dtValue.Rows.Count > 0)
				{
					if(m_hasPatientIDAndDate.Count > 0)
					{
						string[] strKeysArr2 = new string[m_hasPatientIDAndDate.Count];
						m_hasPatientIDAndDate.Keys.CopyTo(strKeysArr2,0);
						foreach(string key in strKeysArr2)
						{
							bool blnIsFound = false;
							foreach(DataRow row in dtValue.Rows)
							{
								if(key == row["INPATIENTID"].ToString().Trim() + DateTime.Parse(row["INPATIENTDATE"].ToString()).ToString("yyyy年MM月dd日"))
								{
									blnIsFound = true;
									break;
								}
							}
							if(!blnIsFound)
							{
								m_hasPatientIDAndDate.Remove(key);
								string[] strKeysArr3 = new string[m_hasPatientID.Count];
								m_hasPatientID.Keys.CopyTo(strKeysArr3,0);
								foreach(string key1 in strKeysArr2)
								{
									blnIsFound = false;
									foreach(DataRow row in dtValue.Rows)
									{
										if(key1 == row["INPATIENTID"].ToString().Trim())
										{
											blnIsFound = true;
											break;
										}
									}
									if(!blnIsFound)
										m_hasPatientID.Remove(key1);
								}
							}
						}
					}
					else
					{
						for(int i=0;i<dtValue.Rows.Count;i++)
						{
							string strPatientID = dtValue.Rows[i]["INPATIENTID"].ToString().Trim();
							string strInPatientDate = DateTime.Parse(dtValue.Rows[i]["INPATIENTDATE"].ToString()).ToString("yyyy年MM月dd日");
							if(m_hasPatientIDAndDate.ContainsKey(strPatientID+strInPatientDate))
							{
								continue;
							}
							m_hasPatientIDAndDate.Add(strPatientID+strInPatientDate,dtValue.Rows[i]);
							if(!m_hasPatientID.ContainsKey(strPatientID))
								m_hasPatientID.Add(strPatientID,"");
						}
					}
				}
                e.EndMessage = "搜索完成";
                Application.DoEvents();
				e.Closing = true;
			}
			catch
			{
                e.EndMessage = "搜索失败";
                Application.DoEvents();
				e.Closing = false;
			}
			finally
			{
				m_mthAddResultToListView();
				m_mthClear();
			}
		}

        private bool m_blnSearchOrders()
        {
            bool blnTemp = false;
            for (int i = 0; i < m_lstConditionList.Items.Count; i++)
            {
                clsDateSearchesCondition objCondition = m_lstConditionList.Items[i] as clsDateSearchesCondition;
                if (objCondition.m_strSQLKey == "S14")
                {
                    blnTemp = true;
                    break;
                }
            }
            return blnTemp;
        }

		private void m_mthClear()
		{
			m_hasPatientID.Clear();
			m_hasPatientIDAndDate.Clear();
		}

		private void m_mniClearCondition_Click(object sender, System.EventArgs e)
		{
			if(m_lstConditionList.Items.Count > 0)
				m_lstConditionList.Items.Clear();
            m_arlFindOrderSQL.Clear();
		}

		private void m_mniDeleteCondition_Click(object sender, System.EventArgs e)
		{
			if(m_lstConditionList.SelectedItems.Count > 0)
				m_lstConditionList.Items.Remove(m_lstConditionList.SelectedItems[0]);
            if (m_lstConditionList.SelectedItems.Count > 0)
            {
                clsDateSearchesCondition objCondition = m_lstConditionList.SelectedItems[0] as clsDateSearchesCondition;
                if (objCondition != null && objCondition.m_strSQLKey == "S14")
                {
                    m_mthDelSelectedOrderSQL(objCondition);
                }
            }
		}

        /// <summary>
        /// 去除选择的医嘱查询语句
        /// </summary>
        /// <param name="p_objCondition"></param>
        private void m_mthDelSelectedOrderSQL(clsDateSearchesCondition p_objCondition)
        {
            if (p_objCondition == null)
                return;

            if (m_arlFindOrderSQL != null)
            {
                for (int i = 0; i < m_arlFindOrderSQL.Count; i++)
                {
                    if (((clsDataSearchesType)m_arlFindOrderSQL[i]).m_strItemDesc == p_objCondition.m_strName
                        && !p_objCondition.m_blnBoolValue)//医嘱查询当条件为false时才将SQL拼湊进来
                    {
                        m_arlFindOrderSQL.RemoveAt(i);
                    }
                }
            }
        }

        private void m_mniModifyCondition_Click(object sender, System.EventArgs e)
		{
			if(m_lstConditionList.SelectedItems.Count <= 0)
				return;
			clsDateSearchesCondition objCondition = m_lstConditionList.SelectedItems[0] as clsDateSearchesCondition;
            m_lstConditionList.Items.Remove(m_lstConditionList.SelectedItems[0]);

            if (objCondition != null && objCondition.m_strSQLKey == "S14")
            {
                m_mthDelSelectedOrderSQL(objCondition);
            }
			//根据条件查找并选中结点
			m_mthFoundNode(objCondition.m_strName);
			//根据不同类型还原条件
			if(m_pnlLongText.Visible)
			{
				m_cboLongTextConditionType.SelectedItem = objCondition.m_objSelectedItem;
				m_txtLongTextContent.Text = objCondition.m_strFirstValue;
			}
			else if(m_pnlDate.Visible)
			{
				m_cboDateConditionType.SelectedItem = objCondition.m_objSelectedItem;
				try
				{
					m_dtpFirst.Value = DateTime.Parse(objCondition.m_strFirstValue.Replace("<FIRST>",""));
				}
				catch{m_dtpFirst.Value = DateTime.Now;}
				try
				{
					if(m_dtpSecond.Visible)
						m_dtpSecond.Value = DateTime.Parse(objCondition.m_strSecondValue.Replace("<SECOND>",""));
				}
				catch{m_dtpSecond.Value = DateTime.Now;}
			}
			else if(m_pnlNumber.Visible)
			{
				m_cboNumberConditionType.SelectedItem = objCondition.m_objSelectedItem;
				m_txtNumberFrom.Text = objCondition.m_strFirstValue.Replace("<FIRST>","");
				if(m_txtNumberTo.Visible)
					m_txtNumberTo.Text = objCondition.m_strSecondValue.Replace("<SECOND>","");
			}
			else if(m_pnlTrueFalse.Visible)
			{
				m_rdbTrueFalseTrue.Checked = objCondition.m_blnBoolValue;
			}
		}

		private void m_lsvPatientList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_lsvPatientList.SelectedItems.Count <=0)
				return;
			clsPatient objPatient = m_lsvPatientList.SelectedItems[0].Tag as clsPatient;
			string strSelectedOutDate = "";
            DateTime dtmSelectedInDate = DateTime.MinValue;
            DateTime dtmSelectedHISInDate = DateTime.MinValue;
			if(objPatient == null)
			{
				
				//查新表，打开相应表单同步病人信息
//				clsPatient objNew = new clsPatient(((DataRow)m_lsvPatientList.SelectedItems[0].Tag)["inpatientid"].ToString());
//				clsPatientInBedInfo objNewBed = new clsPatientInBedInfo(objNew);
//				string strNewDept = "";
//				string strNewArea = "";
//				string strNewBed = "";
//				if(objNewBed != null && objNewBed.m_ObjLastSessionInfo != null)
//				{
//					strNewDept = objNewBed.m_strNewDeptIDForSearch;
//					strNewArea = objNewBed.m_strNewAreaIDForSearch;
//					if(objNewBed.m_ObjLastRoomInfo.m_intGetBedCount() > 0)
//						strNewBed = objNewBed.m_ObjLastRoomInfo.m_objGetBedByIndex(0).m_ObjBed.m_StrBedName;
//				}
				//clsPatient objPatient = new clsPatient((string)(m_lsvPatientList.SelectedItems[0].Tag));
//				objPatient = new clsPatient(((DataRow)m_lsvPatientList.SelectedItems[0].Tag)["inpatientid"].ToString(),true);
//				objPatient.m_strDeptNewID = strNewDept;
//				objPatient.m_strAreaNewID = strNewArea;
//				objPatient.m_strBedCode = strNewBed;

                DataRow drPatientInfo = m_lsvPatientList.SelectedItems[0].Tag as DataRow;
                if (drPatientInfo == null)
                {
                    return;
                }

                if (drPatientInfo["EMRINPATIENTID"] == DBNull.Value)
					return;

                //clsPeopleInfo objPeopleInfo = new clsPeopleInfo();
                //objPeopleInfo.m_StrLastName = drPatientInfo["FirstName"].ToString();
                //objPeopleInfo.m_StrFirstName = drPatientInfo["FirstName"].ToString();

                //objPatient = new clsPatient(drPatientInfo["EMRINPATIENTID"].ToString(),
                //    drPatientInfo["inpatientid"].ToString(), objPeopleInfo);
                objPatient = new clsPatient(true, drPatientInfo["registerid_chr"].ToString());

                objPatient.m_strDeptNewID = drPatientInfo["DeptID"].ToString();
                objPatient.m_strAreaNewID = drPatientInfo["AreaID"].ToString();
                //clsPatientInBedInfo objNewBed = new clsPatientInBedInfo(objPatient);
                //if(objNewBed != null && objNewBed.m_ObjLastSessionInfo != null)
                //{
                //    objPatient.m_strDeptNewID = objNewBed.m_strNewDeptIDForSearch;;
                //    objPatient.m_strAreaNewID = objNewBed.m_strNewAreaIDForSearch;
                //    if(objNewBed.m_ObjLastRoomInfo.m_intGetBedCount() > 0)
                //        objPatient.m_strBedCode = objNewBed.m_ObjLastRoomInfo.m_objGetBedByIndex(0).m_ObjBed.m_StrBedName;
                //}
                objPatient.m_DtmSelectedInDate = DateTime.Parse(drPatientInfo["EMRINPATIENTDATE"].ToString());
                objPatient.m_DtmSelectedHISInDate = DateTime.Parse(drPatientInfo["inpatientdate"].ToString());

                dtmSelectedInDate = objPatient.m_DtmSelectedInDate;
                dtmSelectedHISInDate = objPatient.m_DtmSelectedHISInDate;

                strSelectedOutDate = drPatientInfo["OutDate"].ToString();
                if (!string.IsNullOrEmpty(strSelectedOutDate))
                {
                    objPatient.m_DtmSelectedOutDate = DateTime.Parse(strSelectedOutDate);
                    strSelectedOutDate = DateTime.Parse(strSelectedOutDate).ToString("yyyy年MM月dd日 HH:mm");
                }
				m_lsvPatientList.SelectedItems[0].Tag = objPatient;
            }
            else
            {
                if (objPatient.m_DtmSelectedOutDate != DateTime.MaxValue && objPatient.m_DtmSelectedOutDate.ToString("yyyy-MM-dd") != "1900-01-01")
                    strSelectedOutDate = objPatient.m_DtmSelectedOutDate.ToString("yyyy年MM月dd日 HH:mm");
            }

			m_txtPatientInfo.Text = objPatient.m_StrName + "  " + objPatient.m_StrSex + "  " + objPatient.m_ObjPeopleInfo.m_IntAge + "  " +objPatient.m_ObjPeopleInfo.m_StrMarried;
            m_txtPatientInfo.Text += "\r\n" + objPatient.m_DtmSelectedHISInDate.ToString("yyyy年MM月dd日 HH:mm") + "入院  " + "\r\n" + (strSelectedOutDate == "" ? "未" : strSelectedOutDate) + "出院";
            m_txtPatientInfo.Text += "\r\n" + objPatient.m_ObjPeopleInfo.m_StrHomeplace + "  " + objPatient.m_ObjPeopleInfo.m_Strhome_street;

            //获取m_ObjPeopleInfo时可能会将入院时间更改为最新一次入院时间，需重新赋值
            if (dtmSelectedInDate != DateTime.MinValue && dtmSelectedHISInDate != DateTime.MinValue)
            {
                objPatient.m_DtmSelectedInDate = dtmSelectedInDate;
                objPatient.m_DtmSelectedHISInDate = dtmSelectedHISInDate;
            }

			m_txtPatientInfo.Tag = objPatient;

            clsEmrDept_VO objCurrentDept = new clsEmrDept_VO();
            objCurrentDept.m_strDEPTID_CHR = objPatient.m_strAreaNewID;
            com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment = objCurrentDept;
            #region 初始化com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient
            com.digitalwave.emr.HospitalManagerService.clsHospitalManagerService objServ =
            (com.digitalwave.emr.HospitalManagerService.clsHospitalManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.emr.HospitalManagerService.clsHospitalManagerService));

            //string strRegisterID = "";
            clsEmrInBedPatient_VO objPatientTemp = new clsEmrInBedPatient_VO();
            long lngRes = objServ.m_lngGetPatinetByRegisterID(null, objPatient.m_StrRegisterId, out objPatientTemp);
            
            //objPatientTemp.m_strREGISTERID_CHR = objPatient.m_StrRegisterId;
            //objPatientTemp.m_strPATIENTID_CHR = objPatient.m_StrPatientID;
            //objPatientTemp.m_strEMRInPatientID = objPatient.m_StrEMRInPatientID;
            com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient = objPatientTemp; 
            #endregion
		}

		private void m_cmdClearCondition_Click(object sender, System.EventArgs e)
		{
			m_mniClearCondition.PerformClick();
		}

		private void m_mthMenuItem_Click(object sender, System.EventArgs e)
		{
            if (((MenuItem)sender).Text == "医嘱" || ((MenuItem)sender).Text == "检查" || ((MenuItem)sender).Text == "检验")
                return;
			if(!(m_txtPatientInfo.Tag is clsPatient))
				return;
			Form frmRecord = null;
			frmRecord = m_objRecordSearchDomain.m_frmGetForm((MenuItem)sender);
			if(frmRecord == null)
			{
				string strTypeID = m_strGetTypeId(((MenuItem)sender).Text);
				try
				{
                    Assembly objAsm = Assembly.LoadFrom("Emr_InpatMedRec.dll");
                    object obj = objAsm.CreateInstance("iCare." + strTypeID);
					frmRecord = (Form)obj;
				}
				catch{}
			}
			m_mthOpenForm(frmRecord);
			
		}
		private void m_txtLongTextContent_GotFocus(object sender, System.EventArgs e)
		{
			if(m_txtLongTextContent.Text.Length > 0)
				m_txtLongTextContent.SelectAll();
		}

		
		private void m_trvMain_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
            m_mthTemplate2Node(e.Node);

			if(e.Node.Tag is clsKeyAndFormName)
				m_mthLoadMineElement(e);
			else if(e.Node.Tag is clsCustom_SubmitValue)
				m_mthLoadCustomFormFields(e.Node);
		}
		
        private void m_mthTemplate2Node(TreeNode p_trnCurrent)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (p_trnCurrent.Parent == null)
                {
                    clsKeyAndFormName objKey = p_trnCurrent.Tag as clsKeyAndFormName;
                    if (objKey != null)
                    {
                        m_mthFoundAndSetTemplate2Node(p_trnCurrent, objKey.m_strFormID);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

		private void m_trvMain_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(m_trvMain.SelectedNode == null || m_trvMain.SelectedNode.Tag == null || m_trvMain.SelectedNode.Parent == null)
			{
				m_cmdAddCondition.Enabled = false;
				return;
			}
			string strType = "";
			clsDataSearchesType objSearchesType = m_trvMain.SelectedNode.Tag as clsDataSearchesType;
			if(objSearchesType != null)
				strType = objSearchesType.m_strDataType;
			else if(m_trvMain.SelectedNode.Tag is CustomForm.clsCustomSyncField)//对自定义表单的支持
				strType = "STRING";
			m_mthSetInputVisible(strType);
		}
		
		private void m_lstConditionList_DoubleClick(object sender, System.EventArgs e)
		{
			m_mniModifyCondition.PerformClick();
		}
		private void m_trvMain_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
          

            // Set up the delays for the ToolTip.

            // Force the ToolTip text to be displayed whether or not the form is active.
          
            //.Net 2005会闪动，暂时屏蔽此功能2006-02-10
            TreeNode node = m_trvMain.GetNodeAt(e.X,e.Y);
            if(node != null)
            {
                if (node.Bounds.Contains(e.X, e.Y))
                {
                    if (node.ToolTipText == "")
                    {
                        m_mthSetToolTips(node);
                        if (node.ToolTipText != "")
                        {
                            m_trvMain_MouseMove(sender, e);
                        }
                    }
                }
                    
            }
           // m_trvMain_MouseMove(sender, e);
            
		}
        #endregion

        private void m_mthSetToolTips(TreeNode p_trnSender)
		{
			if(p_trnSender.Tag is clsKeyAndFormName)
			{
				if(((clsKeyAndFormName)p_trnSender.Tag).m_strTemplateID != "")
				{
                    p_trnSender.ToolTipText = "最小元素模板";
					//ttpMain.SetToolTip(m_trvMain,"最小元素模板");
					//ttpMain.Active = true;
				}
			}
			else if(p_trnSender.Tag is clsDataSearchesType)
			{
                if (p_trnSender.Parent.Tag is clsKeyAndFormName)
				{
                    
                    if(((clsKeyAndFormName)p_trnSender.Parent.Tag).m_strTemplateID != "")
					{
                        p_trnSender.ToolTipText = "最小元素";
						//ttpMain.SetToolTip(m_trvMain,"最小元素");
						//ttpMain.Active = true;
						return;
					}
				}
                p_trnSender.ToolTipText = "基本元素";
				//ttpMain.SetToolTip(m_trvMain,"基本元素");
				//ttpMain.Active = true;
			}
			else if(p_trnSender.Tag is CustomForm.clsCustomSyncField)
			{
                p_trnSender.ToolTipText = "自定义表单字段";
				//ttpMain.SetToolTip(m_trvMain,"自定义表单字段");
				//ttpMain.Active = true;
			}
			else if(p_trnSender.Tag is clsCustom_Type)
			{
                p_trnSender.ToolTipText = "自定义表单分类";
				//ttpMain.SetToolTip(m_trvMain,"自定义表单分类");
				//ttpMain.Active = true;
			}
			else if(p_trnSender.Tag is clsCustom_SubmitValue)
			{
                p_trnSender.ToolTipText = "自定义表单";
				//ttpMain.SetToolTip(m_trvMain,"自定义表单");
				//ttpMain.Active = true;
			}
			
		}
		private void m_mthAddCustomFormCondotion(TreeNode p_trnSelectedNode)
		{
			clsCustomSearchesCondition objCondition = new clsCustomSearchesCondition();
			objCondition.m_objSelectedItem = m_cboLongTextConditionType.SelectedItem as clsExpressionInfo;
			objCondition.m_objSyncField = p_trnSelectedNode.Tag as CustomForm.clsCustomSyncField;
			objCondition.m_strFirstValue = m_txtLongTextContent.Text.Trim();
			objCondition.m_strName = p_trnSelectedNode.FullPath;
			for(int i=0;i<m_lstConditionList.Items.Count;i++)
			{
				//控制不能插入重复条件
				if(m_lstConditionList.Items[i] is clsCustomSearchesCondition)
					if(((clsCustomSearchesCondition)m_lstConditionList.Items[i]).ToString() == objCondition.ToString())
						return;
			}
			m_lstConditionList.Items.Add(objCondition);
		}
		private void m_mthSearchesCustomFormData(clsCustomSearchesCondition p_objCustomCondition)
		{
			if(p_objCustomCondition == null)
				return;
			clsCustom_Data[] objCustomDataArr = null;
            long lngRes = new CustomForm.clsCustomFormDomain().m_lngGetAllForSeachRecords(out objCustomDataArr);
			if(lngRes > 0 && objCustomDataArr != null)
			{
                clsCustom_Data objData = null;
				#region ByXPath mark now
//				try
//				{
//					System.Xml.XmlDocument x = new System.Xml.XmlDocument();
//					XmlParserContext objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,System.Text.Encoding.Default);
//					for(int i=0;i<objCustomDataArr.Length;i++)
//					{
//						if(objCustomDataArr[i].m_strInPatientID != null && objCustomDataArr[i].m_strInPatientID != string.Empty)
//						{
//							XmlTextReader objReader = new XmlTextReader(objCustomDataArr[i].m_strContent,XmlNodeType.Element,objXmlParser);
//							x.Load(objReader);
//							string str = m_strGetXPathExp(p_objCustomCondition.m_objSyncField.m_strFieldID,p_objCustomCondition.m_strFirstValue,p_objCustomCondition.m_objSelectedItem.m_strType);
//							if(str != null)
//							{
//								System.Xml.XmlNode n = x.DocumentElement.SelectSingleNode(str);
//								if(n != null)
//								{
//									m_mthAddPatientByCustom(objCustomDataArr[i].m_strInPatientID,objCustomDataArr[i].m_dtmInPatientDate);
//								}
//							}
//						}
//					}
//				}
//				catch(Exception ex)
//				{
//					string str = ex.Message;
//				}
				#endregion ByXPath
				XmlParserContext objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,System.Text.Encoding.Default);
				for(int i=0;i<objCustomDataArr.Length;i++)
				{
                    objData = objCustomDataArr[i];
					if(objData.m_strInPatientID != null && objData.m_strInPatientID != string.Empty)
					{
						XmlTextReader objReader = new XmlTextReader(objData.m_strContent,XmlNodeType.Element,objXmlParser);
						objReader.WhitespaceHandling = WhitespaceHandling.None;
						while(objReader.Read())
						{
							switch(objReader.NodeType)
							{
								case XmlNodeType.Element:
									string strValue = objReader.GetAttribute("VALUE");
									if(strValue != null)
									{
                                        if (m_blnHaveMatchingPatient(p_objCustomCondition.m_strFirstValue, strValue, p_objCustomCondition.m_objSelectedItem.m_strType) && !string.IsNullOrEmpty(objData.m_strRegisterId))
										{
                                            m_mthAddPatientByCustom(objData.m_strInPatientID, objData.m_dtmInPatientDate, objData.m_strRegisterId);
										}
									}
									break;
							}
						}//end while
					}
				}
			}
		}
		private void m_mthAddPatientByCustom(string p_strInPatientID,DateTime p_dtmInPatientDate,string m_strRegisterId)
		{
			if(m_hasPatientIDAndDate.ContainsKey(p_strInPatientID+p_dtmInPatientDate.ToString("yyyy年MM月dd日")))
				return;
			
            clsPatient objPatient = new clsPatient(true,m_strRegisterId);
			objPatient.m_DtmSelectedInDate = p_dtmInPatientDate;
			m_hasPatientIDAndDate.Add(p_strInPatientID+p_dtmInPatientDate.ToString("yyyy年MM月dd日"),objPatient);
			if(!m_hasPatientID.ContainsKey(p_strInPatientID))
				m_hasPatientID.Add(p_strInPatientID,"");
		}
		private void m_mthAddResultToListView()
		{
			if(m_hasPatientIDAndDate.Count > 0)
			{
				string[] strKeysArr = new string[m_hasPatientIDAndDate.Count];
				m_hasPatientIDAndDate.Keys.CopyTo(strKeysArr,0);
				foreach(string key in strKeysArr)
				{
					clsPatient objPatient = m_hasPatientIDAndDate[key] as clsPatient;
					DataRow drList = m_hasPatientIDAndDate[key] as DataRow;
					if(objPatient != null)
					{
						ListViewItem item = new ListViewItem(new string[]{objPatient.m_StrName,objPatient.m_StrInPatientID,objPatient.m_DtmSelectedInDate.ToString("yyyy年MM月dd日")});
						item.Tag = objPatient;
						m_lsvPatientList.Items.Add(item);
					}
					else if(drList != null)
					{
						ListViewItem item = new ListViewItem(new string[]{drList["FIRSTNAME"].ToString(),
                            drList["INPATIENTID"].ToString().Trim(),
                            DateTime.Parse(drList["INPATIENTDATE"].ToString()).ToString("yyyy年MM月dd日")});
						item.Tag = drList;
						m_lsvPatientList.Items.Add(item);
					}
				}
			}
			if(m_lsvPatientList.Items.Count > 0)
				m_lsvPatientList.Items[0].Selected = true;
			m_lblPatientCount.Text = "人数："+m_hasPatientID.Count.ToString();
			m_lblPatientTimesCount.Text = "人次："+m_hasPatientIDAndDate.Count.ToString();
		}
		private bool m_blnHaveMatchingPatient(string p_strCondition,string p_strSource,string p_strExpType)
		{
			switch(p_strExpType)
			{
				case "内容包含":
					int intIndex = p_strSource.IndexOf(p_strCondition);
					if(intIndex >= 0)
						return true;
					return false;;
				case "内容是":
					return p_strSource.Equals(p_strCondition);
				case "内容开头是":
					return p_strSource.StartsWith(p_strCondition);
				case "内容结尾是":
					return p_strSource.EndsWith(p_strCondition);
				default :
					return false;
			}
		}

		#region ByXPath mark now
//		private string m_strGetXPathExp(string p_strFieldID,string p_strValue,string p_strExpType)
//		{
//			switch(p_strExpType)
//			{
//				case "内容包含":
//					return p_strFieldID + "[contains(@VALUE,'"+p_strValue+"')]";
//				case "内容是":
//					return p_strFieldID + "[@VALUE = '"+p_strValue+"']";
//				case "内容开头是":
//					return p_strFieldID +"[starts-with(@VALUE,'"+p_strValue+"')]";
//				case "内容结尾是":
//					return p_strFieldID + "[contains(@VALUE,'"+p_strValue+"')]";
//				default :
//					return null;
//			}
//		}
		#endregion

		private void m_mthSetMenuItemVisible()
		{
			//判断是否广西人民医院
			if(clsEMRLogin.m_StrCurrentHospitalNO != null && clsEMRLogin.m_StrCurrentHospitalNO.Trim() == "450101001")
			{
				menuItem38.Visible = false;//入院病人评估
				menuItem41.Visible = false;//观察项目记录表
			}
		}

        #region 查询科室范围选择
        private void m_mthGetDeptInfo()
        {
            try
            {
                clsHospitalManagerDomain objDomain = new clsHospitalManagerDomain();
                clsEmrDept_VO[] objDeptInfoArr = null;
                long lngRes = objDomain.m_lngGetDeptAreaInfo(clsEMRLogin.LoginInfo.m_strEmpID, out objDeptInfoArr);
                if (lngRes <= 0)
                {
                    if (lngRes == (long)iCareData.enmOperationResult.Not_permission)
                        clsPublicFunction.ShowInformationMessageBox("权限不足!");
                    else
                        clsPublicFunction.ShowInformationMessageBox("数据库连接失败!");
                    return;
                }

                bool blnWantDept = false;//是否需要添加科室(除南宁外其它医院员工都关联到病区，无需显示科室)
                if (clsEMRLogin.m_StrCurrentHospitalNO == "450101001")//南宁
                {
                    blnWantDept = true;
                }

                if (objDeptInfoArr != null)
                {
                    for (int i = 0; i < objDeptInfoArr.Length; i++)
                    {
                        //除南宁外其它医院员工都关联到病区，无需显示科室
                        if (!blnWantDept && objDeptInfoArr[i].m_strATTRIBUTEID == "0000002")
                        {
                            continue;
                        }
                        m_cboDept.AddItem(objDeptInfoArr[i]);
                    }
                    m_cboDept.SelectedIndex = 0;
                    m_chkCurrentDept.Checked = true;
                }
                else                
                {
                    m_chkAllDept.Checked = true;
                }
            }
            catch (Exception exp)
            {
                string strErrMessage = exp.Message + "\n at Module:[" + exp.TargetSite.ReflectedType.Name + "]\n  Method:[" + exp.TargetSite.Name + "]";
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.Log2File(MDIParent.s_strErrorFilePath, "Exception: \r\n" + strErrMessage);
                MessageBox.Show(strErrMessage, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void m_chkAllDept_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkAllDept.Checked)
            {
                m_chkCurrentDept.Checked = false;
            }
        }

        private void m_chkCurrentDept_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkCurrentDept.Checked)
            {
                m_chkAllDept.Checked = false;
                m_cboDept.Enabled = true;
            }
            else
            {
                m_cboDept.Enabled = false;
            }
        } 
        #endregion

        #region 打开医嘱
        private void m_mniOrder_Click(object sender, EventArgs e)
        {
            clsPatient objPatient = m_txtPatientInfo.Tag as clsPatient;
            if(objPatient == null)
				return;

            MDIParent.s_ObjCurrentPatient = objPatient;
            com.digitalwave.iCare.gui.HIS.frmDoctorOrder frmOrder = new com.digitalwave.iCare.gui.HIS.frmDoctorOrder();
            frmOrder.MdiParent = clsEMRLogin.s_FrmMDI;
            frmOrder.WindowState = FormWindowState.Maximized;
            frmOrder.Show();
            //frmOrder.m_mthGetSpecifyPatientForm(objPatient.m_StrHISInPatientID);
        } 
        #endregion

        #region 打开检验查询
        private void m_mniCheckOut_Click(object sender, EventArgs e)
        {
            clsPatient objPatient = m_txtPatientInfo.Tag as clsPatient;
            if (objPatient == null)
                return;

            MDIParent.s_ObjCurrentPatient = objPatient;
            com.digitalwave.iCare.gui.HIS.frmClinicalLab_QueryMain frmCheckOut = new com.digitalwave.iCare.gui.HIS.frmClinicalLab_QueryMain();
            frmCheckOut.MdiParent = clsEMRLogin.s_FrmMDI;
            frmCheckOut.WindowState = FormWindowState.Maximized;
            frmCheckOut.Show();
            frmCheckOut.m_mthGetSpecifyPatientForm(objPatient.m_StrHISInPatientID);
        }
        #endregion

        #region 打开检查查询
        private void m_mniExamine_Click(object sender, EventArgs e)
        {
            clsPatient objPatient = m_txtPatientInfo.Tag as clsPatient;
            if (objPatient == null)
                return;

            MDIParent.s_ObjCurrentPatient = objPatient;
            com.digitalwave.iCare.gui.HIS.frmExamine_Query frmCheckExamine = new com.digitalwave.iCare.gui.HIS.frmExamine_Query();
            frmCheckExamine.MdiParent = clsEMRLogin.s_FrmMDI;
            frmCheckExamine.WindowState = FormWindowState.Maximized;
            frmCheckExamine.Show();
            frmCheckExamine.m_mthGetSpecifyPatientForm(objPatient.m_StrHISInPatientID);
        } 
        #endregion

        private void m_cmsEMRMenu_Opening(object sender, CancelEventArgs e)
        {
            if (m_txtPatientInfo.Tag == null)
            {
                e.Cancel = true;
                return;
            }

            clsPatient objSelectPatient = (clsPatient)m_txtPatientInfo.Tag;

            try
            {
                clsEmrInBedPatient_VO objVO = new clsEmrInBedPatient_VO();
                objVO.m_intCharacter = 1;
                if (clsEMRLogin.m_ObjCurDeptOfEmpArr != null)
                {
                    for (int j1 = 0; j1 < clsEMRLogin.m_ObjCurDeptOfEmpArr.Length; j1++)
                    {
                        if (clsEMRLogin.m_ObjCurDeptOfEmpArr[j1].strDeptID == MDIParent.m_objCurrentDepartment.m_strDEPTID_CHR)
                        {
                            objVO.m_intCharacter = 0;
                            break;
                        }
                    }
                }

                objVO.m_dtmEMRInDate = objSelectPatient.m_DtmSelectedInDate;
                objVO.m_dtmHISInDate = objSelectPatient.m_DtmSelectedHISInDate;
                objVO.m_strHISInPatientID = objSelectPatient.m_StrHISInPatientID;
                objVO.m_strEMRInPatientID = objSelectPatient.m_StrEMRInPatientID;
                objVO.m_strINPATIENT_DAT = objVO.m_dtmEMRInDate.ToString("yyyy-MM-dd HH:mm:ss");
                objVO.m_strINPATIENTID_CHR = objVO.m_strEMRInPatientID;
                objVO.m_strPATIENTID_CHR = objSelectPatient.m_StrPatientID;
                objVO.m_strREGISTERID_CHR = objSelectPatient.m_StrRegisterId;
                objVO.m_strDEPTID_CHR = objSelectPatient.m_strDeptNewID;
                objVO.m_strEXTENDID_VCHR = objSelectPatient.m_StrHISInPatientID;
                objVO.m_strAREAID_CHR = objSelectPatient.m_strAreaNewID;
                objVO.m_strLASTNAME_VCHR = objSelectPatient.m_StrName;
                objVO.m_strCODE_CHR = "";

                MDIParent.m_objCurrentPatient = objVO;
                MDIParent.s_ObjCurrentPatient.m_ObjPeopleInfo = objSelectPatient.m_ObjPeopleInfo;
            }
            catch (Exception ex)
            { string str = ex.Message; }
        }

    }
}
